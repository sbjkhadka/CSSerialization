using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.IO;

namespace LizardDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Lizard> lizards = Lizard.GetLizards();
            //serializeOneLizard("one.txt", lizards[0]);
            //deserializeOneLizard("one.txt");
            //serializeAllLizards("All.txt", lizards);
            deserealizeAllLizards("All.txt");


        }

        static void serializeOneLizard(string filename, Lizard obj)
        {
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            using (TextWriter textwriter = new StreamWriter(filename))
            {
                textwriter.Write(javaScriptSerializer.Serialize(obj));
            }
        }
        static void serializeAllLizards(string filename,List<Lizard> lizards)
        {
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            using (TextWriter textWriter=new StreamWriter(filename))
            {
                textWriter.Write(javaScriptSerializer.Serialize(lizards));
            }
        }
        static void deserializeOneLizard(string filename)
        {
            using (TextReader textreader=new StreamReader(filename))
            {
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                Lizard lizard = javaScriptSerializer.Deserialize<Lizard>(textreader.ReadToEnd());
                Console.WriteLine(lizard);

            }

        }
        static void deserealizeAllLizards(string filename)
           
        {
            using (TextReader textReader=new StreamReader(filename))
            {
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                List <Lizard> lizards= javaScriptSerializer.Deserialize<List<Lizard>>(textReader.ReadToEnd());
                foreach(Lizard lizard in lizards)
                {
                    Console.WriteLine(lizard);
                }
            }
        }
    }
}
