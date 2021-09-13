using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YNHM.Database;

namespace YNHM.WebApp.Controllers
{
    [Authorize]
    public class PayPalController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;
        public ApplicationSignInManager SignInManager
        {
            get { return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>(); }
            private set { _signInManager = value; }
        }
        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }

        public PayPalController()
        {

        }

        public PayPalController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }


        public ActionResult PaymentWithPaypal(string Cancel = null)
        {
            //getting the apiContext  
            APIContext apiContext = PaypalConfiguration.GetAPIContext();
            
            try
            {
                //A resource representing a Payer that funds a payment Payment Method as paypal  
                //Payer Id will be returned when payment proceeds or click to pay  
                string payerId = Request.Params["PayerID"];
                if (string.IsNullOrEmpty(payerId))
                {
                    //this section will be executed first because PayerID doesn't exist  
                    //it is returned by the create function call of the payment class  
                    // Creating a payment  
                    // baseURL is the url on which paypal sendsback the data.  
                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/PayPal/PaymentWithPayPal?";
                    //here we are generating guid for storing the paymentID received in session  
                    //which will be used in the payment execution  
                    var guid = Convert.ToString((new Random()).Next(100000));
                    //CreatePayment function gives us the payment approval url  
                    //on which payer is redirected for paypal account payment  
                    var createdPayment = this.CreatePayment(apiContext, baseURI + "guid=" + guid);
                    //get links returned from paypal in response to Create function call  
                    var links = createdPayment.links.GetEnumerator();
                    string paypalRedirectUrl = null;
                    while (links.MoveNext())
                    {
                        Links lnk = links.Current;
                        if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            //saving the payapalredirect URL to which user will be redirected for payment  
                            paypalRedirectUrl = lnk.href;
                        }
                    }
                    // saving the paymentID in the key guid  
                    Session.Add(guid, createdPayment.id);
                    return Redirect(paypalRedirectUrl);
                }
                else
                {
                    // This function exectues after receving all parameters for the payment  
                    var guid = Request.Params["guid"];
                    var executedPayment = ExecutePayment(apiContext, payerId, Session[guid] as string);
                    //If executed payment failed then we will show payment failure message to user  
                    if (executedPayment.state.ToLower() != "approved")
                    {
                        return View("PaymentFailed");
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["message"] = "We're sorry, something went wrong. Please try again later.";
                return RedirectToAction("Index", "HomePage");
            }

            var userId = User.Identity.GetUserId();
            var user = UserManager.FindById(userId);
            user.IsSubscribed = true;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var roomie = db.Roomies.Find(user.RoomieId);
                roomie.IsSubscribed = true;
                db.Entry(roomie).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            if (user.SubscriptionStarts == null)
            {
                user.SubscriptionStarts = DateTime.Now;
            }

            if (user.SubscriptionExpires == null || user.SubscriptionExpires<DateTime.Now)
            {
                user.SubscriptionExpires = DateTime.Now.AddDays(30);
            }
            else
            {
                user.SubscriptionExpires = user.SubscriptionExpires.Value.AddDays(30);
            }

            var addRole = UserManager.AddToRole(user.Id, "Subscriber");
            if (addRole.Succeeded)
            {
                UserManager.Update(user);
            }

            //on successful payment, show success page to user.

            TempData["message"] = "Your payment has been processed and has been accepted!";
            return RedirectToAction("Index", "HomePage");
        }
        private PayPal.Api.Payment payment;
        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId
            };
            this.payment = new Payment()
            {
                id = paymentId
            };
            return this.payment.Execute(apiContext, paymentExecution);
        }
        private Payment CreatePayment(APIContext apiContext, string redirectUrl)
        {
            Item subscription = new Item()
            {
                name = "YNHM Subscription",
                currency = "EUR",
                price = "14",
                quantity = "1"
            };

            //create itemlist and add item objects to it  
            var itemList = new ItemList()
            {
                items = new List<Item>()
            };
            //Adding Item Details like name, currency, price etc  
            itemList.items.Add(subscription);

            var payer = new Payer()
            {
                payment_method = "paypal"
            };
            // Configure Redirect Urls here with RedirectUrls object  
            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl + "&Cancel=true",
                return_url = redirectUrl
            };
            // Adding Tax, shipping and Subtotal details  
            var details = new Details()
            {
                tax = "1",
                subtotal = subscription.price
            };
            //Final amount with details  
            var amount = new Amount()
            {
                currency = "EUR",
                total = (Convert.ToInt32(details.tax) + Convert.ToInt32(subscription.price)).ToString(),
                details = details
            };
            var transactionList = new List<Transaction>();
            // Adding description about the transaction  
            transactionList.Add(new Transaction()
            {
                description = "Transaction description",
                invoice_number = Convert.ToString(new Random().Next(1000000)),
                amount = amount,
                item_list = itemList
            });
            this.payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };
            // Create a payment using a APIContext  
            return this.payment.Create(apiContext);
        }



    }
}