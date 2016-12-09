using Comp229_Assign04.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using static Comp229_Assign04.Model.CharacterModels;

namespace Comp229_Assign04
{
    public class Global : HttpApplication
    {
        public static string emailID = "cc-comp229f2016@outlook.com";
        public static string emailPassword = "comp229pwd";
        public static string jsonPath = "~/Assign04.json";
        public static List<CharacterModel> characters;

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            setupCharacters();
        }

        private void setupCharacters()
        {
            using (StreamReader streamReader = new StreamReader(System.Web.Hosting.HostingEnvironment.MapPath(jsonPath)))
            {
                var jsonString = streamReader.ReadToEnd();
                characters = JsonConvert.DeserializeObject<List<CharacterModel>>(jsonString);
            }   
          }

        public void updateNewJson(List<CharacterModel> models)
        {
            using (StreamWriter streamWriter
                = File.CreateText(System.Web.Hosting.HostingEnvironment.MapPath(jsonPath)))
            {
                streamWriter.WriteLine(JsonConvert.SerializeObject(models));
            }
        }
    }
}