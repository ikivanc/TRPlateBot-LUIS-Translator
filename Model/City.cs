using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TRPlateBot
{

    public class City
    {
        Dictionary<int, string> types = new Dictionary<int, string>()
    {
        {1,"Adana"},
        {2,"Adiyaman"},
        {3,"Afyonkarahisar"},
        {4,"Agri"},
        {5,"Amasya"},
        {6,"Ankara"},
        {7,"Antalya"},
        {8,"Artvin"},
        {9,"Aydin"},
        {10,"Balikesir"},
        {11,"Bilecik"},
        {12,"Bingöl"},
        {13,"Bitlis"},
        {14,"Bolu"},
        {15,"Burdur"},
        {16,"Bursa"},
        {17,"Çanakkale"},
        {18,"Çankiri"},
        {19,"Çorum"},
        {20,"Denizli"},
        {21,"Diyarbakir"},
        {22,"Edirne"},
        {23,"Elâzig"},
        {24,"Erzincan"},
        {25,"Erzurum"},
        {26,"Eskisehir"},
        {27,"Gaziantep"},
        {28,"Giresun"},
        {29,"Gümüshane"},
        {30,"Hakkari"},
        {31,"Hatay"},
        {32,"Isparta"},
        {33,"Mersin"},
        {34,"Istanbul"},
        {35,"Izmir"},
        {36,"Kars"},
        {37,"Kastamonu"},
        {38,"Kayseri"},
        {39,"Kirklareli"},
        {40,"Kirsehir"},
        {41,"Kocaeli"},
        {42,"Konya"},
        {43,"Kütahya"},
        {44,"Malatya"},
        {45,"Manisa"},
        {46,"Kahramanmaras"},
        {47,"Mardin"},
        {48,"Mugla"},
        {49,"Mus"},
        {50,"Nevsehir"},
        {51,"Nigde"},
        {52,"Ordu"},
        {53,"Rize"},
        {54,"Sakarya"},
        {55,"Samsun"},
        {56,"Siirt"},
        {57,"Sinop"},
        {58,"Sivas"},
        {59,"Tekirdag"},
        {60,"Tokat"},
        {61,"Trabzon"},
        {62,"Tunceli"},
        {63,"Sanliurfa"},
        {64,"Usak"},
        {65,"Van"},
        {66,"Yozgat"},
        {67,"Zonguldak"},
        {68,"Aksaray"},
        {69,"Bayburt"},
        {70,"Karaman"},
        {71,"Kirikkale"},
        {72,"Batman"},
        {73,"Sirnak"},
        {74,"Bartin"},
        {75,"Ardahan"},
        {76,"Igdir"},
        {77,"Yalova"},
        {78,"Karabük"},
        {79,"Kilis"},
        {80,"Osmaniye"},
        {81,"Düzce"}
    };

        public string getCityNamebyPlateNumber(int pNumber)
        {
            string cityName = types.FirstOrDefault(x => x.Key == pNumber).Value;
            return cityName;
        }

        public int getPlateNumberbyCity(string cName)
        {
            int pNumber = types.FirstOrDefault(x => x.Value.ToLower() == cName.ToLower()).Key;

            return pNumber;
        }

    }

}