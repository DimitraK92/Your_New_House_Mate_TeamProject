using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YNHM.Console
{
    class MatchResult
    {
        public int PersonId;
        public float Score;
        public MatchResult(int a,float b)
        {
            this.PersonId = a;
            this.Score = b;
        }

    }
    class Matching
    {
       
        public MatchResult Match(Test test)
        { 
            List<Test> Tests=new List<Test>();
            MatchResult score =null;
            for (int i = 0; i < Tests.Count-1; i++)
            {
                int counter = 0;
                if (test.PetOwner==Tests[i].PetOwner)
                {
                    counter += 1;
                }
                if (test.Smoking==Tests[i].Smoking)
                {
                    counter += 1;
                }
                if (test.musicGenre==Tests[i].musicGenre)
                {
                    counter += 1;
                }
                float pithanotita = counter / 3;
                if (pithanotita>score.Score)
                {
                    score = new MatchResult(Tests[i].PersonId, pithanotita);
                }
                
            }
            return score;

        }
    }
}
