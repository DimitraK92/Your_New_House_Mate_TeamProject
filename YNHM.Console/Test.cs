using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YNHM.Console
{
    class Test
    {
        //primary key
        public int TestId;

        //foreign key
        public int PersonId;

        //properties
        
        public bool Smoking;
        public bool PetOwner;
        public MusicGenre musicGenre;
     }

    public enum MusicGenre
    {
        MetalRock,
        Pop,
        HipHop,
        Reggae
    }
}
