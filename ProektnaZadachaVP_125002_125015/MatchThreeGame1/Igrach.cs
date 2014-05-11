using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace MatchThreeGame
{
    [Serializable]
   public  class Igrach
    {
       public String Ime
       {
           get;
           set;
       }
       public int Poeni
       {
           get;
           set;
       }
       public Igrach()
       {
           Poeni = 0;
       }
       public override string ToString()
       {
           return String.Format("{0,-15}{1,30}",Ime,Poeni);
       }
    }
}
