using System.Web.Optimization;

namespace YNHM.WebApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //----------------------------------------------------------------------------------//
            //Script Bundles
            //----------------------------------------------------------------------------------//

            //Main
            bundles.Add(new ScriptBundle("~/Templates/Listty/StaticHTML/assets/basicScripts").Include(
                "~/Templates/Listty/StaticHTML/assets/plugins/jquery/jquery-3.4.1.min.js",
                "~/Templates/Listty/StaticHTML/assets/plugins/bootstrap/js/bootstrap.bundle.js",
                "~/Templates/Listty/StaticHTML/assets/plugins/menuzord/js/menuzord.js",
                "~/Templates/Listty/StaticHTML/assets/plugins/selectric/jquery.selectric.min.js"));

            //Selectric
            bundles.Add(new ScriptBundle("~/Templates/Listty/StaticHTML/assets/selectric").Include(
                "~/Templates/Listty/StaticHTML/assets/plugins/selectric/jquery.selectric.min.js"
            ));

            //Scroll and lazyestload
            bundles.Add(new ScriptBundle("~/Templates/Listty/StaticHTML/assets/scrollAndLazyLoad").Include(
                "~/Templates/Listty/StaticHTML/assets/plugins/smoothscroll/SmoothScroll.js",
                "~/Templates/Listty/StaticHTML/assets/plugins/lazyestload/lazyestload.js"
                ));


            //Index
            bundles.Add(new ScriptBundle("~/Templates/Listty/StaticHTML/assets/mainScripts").Include(
                "~/Templates/Listty/StaticHTML/assets/plugins/dzsparallaxer/dzsparallaxer.js",

                "~/Templates/Listty/StaticHTML/assets/plugins/revolution/js/jquery.themepunch.tools.min.js",
                "~/Templates/Listty/StaticHTML/assets/plugins/revolution/js/jquery.themepunch.revolution.min.js",
                "~/Templates/Listty/StaticHTML/assets/plugins/smoothscroll/SmoothScroll.js",
                "~/Templates/Listty/StaticHTML/assets/plugins/lazyestload/lazyestload.js",
                "~/Templates/Listty/StaticHTML/assets/plugins/owl-carousel/owl.carousel.min.js"));

            //Houses
            bundles.Add(new ScriptBundle("~/Templates/Listty/StaticHTML/assets/houseScripts").Include(
                "~/Templates/Listty/StaticHTML/assets/plugins/selectric/jquery.selectric.min.js",

                "~/Templates/Listty/StaticHTML/assets/plugins/smoothscroll/SmoothScroll.js",
                "~/Templates/Listty/StaticHTML/assets/plugins/lazyestload/lazyestload.js",

                "~/Templates/Listty/StaticHTML/assets/plugins/map/js/markerclusterer.js",
                "~/Templates/Listty/StaticHTML/assets/plugins/map/js/rich-marker.js",
                "~/Templates/Listty/StaticHTML/assets/plugins/map/js/infobox_packed.js",
                "~/Templates/Listty/StaticHTML/assets/js/map.js"

                ));

            //People
            bundles.Add(new ScriptBundle("~/Templates/Listty/StaticHTML/assets/peopleScripts").Include(
                "~/Templates/Listty/StaticHTML/assets/plugins/selectric/jquery.selectric.min.js",

                "~/Templates/Listty/StaticHTML/assets/plugins/smoothscroll/SmoothScroll.js",
                "~/Templates/Listty/StaticHTML/assets/plugins/lazyestload/lazyestload.js"
                ));

            //Single Listing
            bundles.Add(new ScriptBundle("~/Templates/Listty/StaticHTML/assets/singleListingScripts").Include(
                "~/Templates/Listty/StaticHTML/assets/plugins/fancybox/jquery.fancybox.min.js",
                "~/Templates/Listty/StaticHTML/assets/plugins/daterangepicker/moment.min.js",
                "~/Templates/Listty/StaticHTML/assets/plugins/daterangepicker/daterangepicker.js",

                "~/Templates/Listty/StaticHTML/assets/plugins/smoothscroll/SmoothScroll.js",
                "~/Templates/Listty/StaticHTML/assets/plugins/lazyestload/lazyestload.js",
                "~/Templates/Listty/StaticHTML/assets/plugins/owl-carousel/owl.carousel.min.js",
                "~/Templates/Listty/StaticHTML/assets/plugins/rateyo/jquery.rateyo.min.js",

                "~/Templates/Listty/StaticHTML/assets/plugins/velocity/velocity.min.js",
                //"https://maps.googleapis.com/maps/api/js?key=AIzaSyDU79W1lu5f6PIiuMqNfT1C6M0e_lq1ECY",

                "~/Templates/Listty/StaticHTML/assets/js/map.js"));

            //Login
            bundles.Add(new ScriptBundle("~/Templates/Listty/StaticHTML/assets/loginScripts").Include(
                "~/Templates/Listty/StaticHTML/assets/plugins/smoothscroll/SmoothScroll.js",
                "~/Templates/Listty/StaticHTML/assets/plugins/lazyestload/lazyestload.js"));


            //Signup
            bundles.Add(new ScriptBundle("~/Templates/Listty/StaticHTML/assets/signupScripts").Include(
                "~/Templates/Listty/StaticHTML/assets/plugins/selectric/jquery.selectric.min.js",

                "~/Templates/Listty/StaticHTML/assets/plugins/smoothscroll/SmoothScroll.js",
                "~/Templates/Listty/StaticHTML/assets/plugins/lazyestload/lazyestload.js"));

            //Pairs
            bundles.Add(new ScriptBundle("~/Templates/Listty/StaticHTML/assets/pairScripts").Include(
                "~/Templates/Listty/StaticHTML/assets/plugins/DataTables/DataTables-1.10.18/js/jquery.dataTables.min.js",
                "~/Templates/Listty/StaticHTML/assets/plugins/DataTables/Responsive-2.2.2/js/dataTables.responsive.min.js"));

            //----------------------------------------------------------------------------------//
            //Style Bundles
            //----------------------------------------------------------------------------------//

            //Basic
            bundles.Add(new Bundle("~/Templates/Listty/StaticHTML/assets/basicStyle").Include(
                "~/Templates/Listty/StaticHTML/assets/plugins/fontawesome-5.15.2/css/all.min.css",
                "~/Templates/Listty/StaticHTML/assets/plugins/fontawesome-5.15.2/css/fontawesome.min.css",
                "~/Templates/Listty/StaticHTML/assets/plugins/listtyicons/style.css",
                "~/Templates/Listty/StaticHTML/assets/plugins/menuzord/css/menuzord.css",
                "~/Templates/Listty/StaticHTML/assets/plugins/selectric/selectric.css"));

            bundles.Add(new Bundle("~/Templates/Listty/StaticHTML/assets/styleAndColor").Include(
                "~/Templates/Listty/StaticHTML/assets/css/color4.css"));

            bundles.Add(new Bundle("~/Templates/Listty/StaticHTML/assets/selectric").Include(
                "~/Templates/Listty/StaticHTML/assets/plugins/selectric/selectric.css"));

            //Index
            bundles.Add(new StyleBundle("~/Templates/Listty/StaticHTML/assets/mainStyle").Include(
                "~/Templates/Listty/StaticHTML/assets/plugins/dzsparallaxer/dzsparallaxer.css",

                "~/Templates/Listty/StaticHTML/assets/plugins/owl-carousel/assets/owl.carousel.min.css",
                "~/Templates/Listty/StaticHTML/assets/plugins/owl-carousel/assets/owl.theme.default.min.css",
                "~/Templates/Listty/StaticHTML/assets/plugins/revolution/css/settings.css"//,

                //"https://fonts.googleapis.com/css2?family=Mulish:wght@200;300;400;600;700;800;900&family=Poppins:wght@300;400;500;600;700&display=swap"
                ));

            //Houses, People, Take Test
            bundles.Add(new StyleBundle("~/Templates/Listty/StaticHTML/assets/listingStyle").Include(
                "~/Templates/Listty/StaticHTML/assets/plugins/selectric/selectric.css",

                "~/Templates/Listty/StaticHTML/assets/plugins/map/css/map.css"

                //"https://fonts.googleapis.com/css2?family=Mulish:wght@200;300;400;600;700;800;900&family=Poppins:wght@300;400;500;600;700&display=swap"
                ));

            //Single Listing
            bundles.Add(new StyleBundle("~/Templates/Listty/StaticHTML/assets/singleListing").Include(
                "~/Templates/Listty/StaticHTML/assets/plugins/fancybox/jquery.fancybox.min.css",
                "~/Templates/Listty/StaticHTML/assets/plugins/owl-carousel/assets/owl.carousel.min.css",
                "~/Templates/Listty/StaticHTML/assets/plugins/owl-carousel/assets/owl.theme.default.min.css",

                "~/Templates/Listty/StaticHTML/assets/plugins/map/css/map.css",
                "~/Templates/Listty/StaticHTML/assets/plugins/rateyo/jquery.rateyo.min.css",

                "~/Templates/Listty/StaticHTML/assets/plugins/daterangepicker/daterangepicker.css"

                //"https://fonts.googleapis.com/css2?family=Mulish:wght@200;300;400;600;700;800;900&family=Poppins:wght@300;400;500;600;700&display=swap",
                ));

            //Login
            bundles.Add(new StyleBundle("~/Templates/Listty/StaticHTML/assets/loginStyle").Include(
                "~/Templates/Listty/StaticHTML/assets/css/color4.css"));

            //Signup
            bundles.Add(new StyleBundle("~/Templates/Listty/StaticHTML/assets/signupStyle").Include(
                "~/Templates/Listty/StaticHTML/assets/plugins/selectric/selectric.css"));

            //User pairs
            bundles.Add(new StyleBundle("~/Templates/Listty/StaticHTML/assets/pairsStyle").Include(
                "~/Templates/Listty/StaticHTML/assets/plugins/DataTables/DataTables-1.10.18/css/jquery.dataTables.min.css",
                "~/Templates/Listty/StaticHTML/assets/plugins/DataTables/Responsive-2.2.2/css/responsive.dataTables.min.css"));
        }
    }
}
