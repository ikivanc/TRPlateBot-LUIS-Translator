namespace TRPlateBot
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Bot.Builder.Dialogs;
    using Microsoft.Bot.Builder.Luis;
    using Microsoft.Bot.Builder.Luis.Models;
    using Microsoft.Bot.Connector;
    using Microsoft.Bot.Builder.FormFlow;

    [LuisModel("<YOUR_LUIS_APP_ID>", "YOUR_SUBSCRIPTION_KEY")]
    [Serializable]
    public class RootLuisDialog : LuisDialog<object>
    {
        //Eğer sorulan cümle anlaşılamazsa düşeceği default method. 
        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = $"Üzgünüm, '{result.Query}' içeriğini tam olarak anlayamadım. Size nasıl yardımcı olacağımı 'help' veya 'help me' yazarak öğrenebilirsiniz..";
            await context.PostAsync(message);

            context.Wait(this.MessageReceived);
        }

        //LUIS üzerinde oluşturduğumuz yardım bölümü, yardım isteklerinie göre düşebilirler. 
        [LuisIntent("Help")]
        public async Task Help(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Selam! Bana 'What's the plate number of İstanbul?', 'Show me the city code of Ankara' or 'Which city is using 45' gibi sorular sorabilirsiniz.");

            context.Wait(this.MessageReceived);
        }

        // LUIS üzerinde oluşturduğumuz ShowCityName intent'i sayesinde plaka kodu verilerek sorulan şehir isimleri bu methodun içne düşmektedir.
        [LuisIntent("ShowCityName")]
        public async Task ShowCityName(IDialogContext context, LuisResult result)
        {
            foreach (var searchEntity in result.Entities)
            {
                City cm = new City();
                string cityName = cm.getCityNamebyPlateNumber(Convert.ToInt32(searchEntity.Entity));

                string message = $"Sorguladığınız {searchEntity.Entity} plaka kodu {cityName} iline aittir.";
                if (cityName == null) message = $"Sorguladığınız {searchEntity.Entity} sorgu kayıtlarımızda bulunamadı";                
                await context.PostAsync(message);

                context.Wait(this.MessageReceived);
            }
        }

    
        // LUIS üzerinde oluşturduğumuz ShowPlateNumber intent'i sayesinde şehir ismi verilerek plaka/şehir kodu sorulduğunda bu methodun içne düşmektedir.
        [LuisIntent("ShowPlateNumber")]
        public async Task ShowPlateNumber(IDialogContext context, LuisResult result)
        {
            foreach (var searchEntity in result.Entities)
            {
                City cm = new City();
                int pNumber = cm.getPlateNumberbyCity(searchEntity.Entity);

                string message = $"Sorguladığınız {searchEntity.Entity}  ilinin plaka kodu: {pNumber}";
                if (pNumber == 0) message = $"Sorguladığınız {searchEntity.Entity} sorgu kayıtlarımızda  bulunamadı";
                await context.PostAsync(message);
                
                context.Wait(this.MessageReceived);
            }
        }


    }
}
