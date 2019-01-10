using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevShop.Data.Constant;
using DevShop.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DevShop.Data
{
    public class DbSeeder
    {
        private readonly DevShopDbContext _ctx;
        private readonly UserManager<ExtendedIdentityUser> _userManager;

        public DbSeeder(DevShopDbContext ctx, UserManager<ExtendedIdentityUser> userManager)
        {
            _ctx = ctx;
            _userManager = userManager;
        }

        //Seed fresh database
        public async Task SeedAsync()
        {
            _ctx.Database.EnsureDeleted();
            _ctx.Database.Migrate();

            var users = new List<ExtendedIdentityUser>()
                {
                    new ExtendedIdentityUser()
                    {
                        PhoneNumber = "123456789",
                        Email = "mddevinternal@gmail.com",
                        UserName = "DevAccount",
                        Address = "Grabiszyńska 166/2, 53-232, Wrocław",
                        FirstName = "Maciej",
                        LastName = "Dudziak"
                    },
                    new ExtendedIdentityUser()
                    {
                    PhoneNumber = "48653138",
                    Email = "karonn@gmail.com",
                    UserName = "Karon99",
                    Address = "Jemiołowa 222/2, 53-232, Wrocław",
                    FirstName = "Karol",
                    LastName = "Nowak"
                    },
                    new ExtendedIdentityUser()
                    {
                    PhoneNumber = "77854321",
                    Email = "matdam343@gmail.com",
                    UserName = "matdam5454",
                    Address = "Jutrzana 434/2, 53-554, Wrocław",
                    FirstName = "Mateusz",
                    LastName = "Damianski"
                  },
                    new ExtendedIdentityUser()
                    {
                        PhoneNumber = "6426542654",
                        Email = "malgan4334@gmail.com",
                        UserName = "malgan231",
                        Address = "Lwowska 2/2, 53-521, Wrocław",
                        FirstName = "Małgorzata",
                        LastName = "Ganak"
                    }
                };

            foreach (var user in users)
            {
                if (await _userManager.CreateAsync(user, "AdminPassword!1") != IdentityResult.Success)
                    throw new InvalidOperationException("Could not create default users.");
            }

            List<Country> countriesToSeed = new List<Country>();
            var countriesList = new CountriesList();
            foreach (var country in countriesList.Countries)
            {
                countriesToSeed.Add(new Country() { Name = country.FullName, ShortName = country.Shortname });
            }
            _ctx.Countries.AddRange(countriesToSeed);

            List<Book> books = new List<Book>()
                {
                    new Book()
                    {
                        Name = "Python. Wprowadzenie.",
                        Description = "Czy wiesz, dlaczego ponad milion programistów na całym świecie używa właśnie tego języka skryptowego? " +
                                      "Jego atuty to niezwykła czytelność, spójność i wydajność — pewnie dlatego także i Ty chcesz opanować słynnego Pythona. " +
                                      "Kod napisany w tym języku można z łatwością utrzymywać, przenosić i używać go ponownie. Pozostaje on zrozumiały nawet wówczas, jeśli analizuje go ktoś, kto nie jest jego autorem. Co więcej, taki kod ma rozmiary średnio o dwie trzecie do czterech piątych mniejsze od kodu w językach C++ czy Java, co wielokrotnie zwiększa wydajność pracy używających go programistów. " +
                                      "Python obsługuje także zaawansowane mechanizmy pozwalające na ponowne wykorzystanie kodu, takie jak programowanie zorientowane obiektowo, a programy w nim napisane działają natychmiast, bez konieczności przeprowadzania długiej kompilacji, niezależnie od wykorzystywanej platformy. Jeśli jesteś gotowy na opanowanie tego potężnego języka, mamy doskonały podręcznik dla Ciebie." +
                                      "\r\n\r\nMark Lutz, autor tego podręcznika, jest kultową postacią w środowisku Pythona i znanym na całym świecie instruktorem tego języka, a struktura jego książki powstała w oparciu o słynny, prowadzony przez niego kurs. Naukę rozpoczniesz od najważniejszych wbudowanych typów danych — liczb, list czy słowników. Przyjrzysz się również typom dynamicznym oraz ich interfejsom. Później poznasz instrukcje oraz ogólny model składni Pythona. Poszerzysz wiedzę na temat powiązanych z nim narzędzi, takich jak system PyDoc, a także alternatywnych możliwości tworzenia kodu. Dowiesz się wszystkiego na temat modułów: jak się je tworzy, przeładowuje i jak się ich używa. W końcu poznasz klasy oraz zagadnienia związane z programowaniem zorientowanym obiektowo i nauczysz się obsługiwać wyjątki. Czwarte wydanie tej książki zostało wzbogacone o wiele nowych, ciekawych i bardzo zaawansowanych zagadnień, dzięki czemu stanowi doskonałą lekturę także dla zawodowców, na co dzień piszących kod w tym języku.",
                        ImgPath = "6e5eb7be92859e2806a11fdaa910f064,pytho4.jpg",
                        Price = 149,
                        UserScore = 4.7,
                        Published = new DateTime(2018,01,01),
                        IsRecommended = true,
                        IsOnLimitedSale = true,
                        LimitedSalePrice = 119,
                        NumberOfPages = 549,
                        DiscountedPrice = 129
                    },
                    new Book()
                    {
                        Name = "Czysta architektura. Struktura i design oprogramowania.",
                        Description = "Pierwsze linie kodu powstawały w połowie ubiegłego wieku. Komputery, na które tworzono te programy, w bardzo niewielkim stopniu przypominały współczesne maszyny. Niezależnie od upływu lat, postępu technologii i powstawania wymyślnych narzędzi, języków programowania czy frameworków pewne zasady tworzenia kodu pozostają niezmienne. Są takie same jak w czasie, gdy Alan Turing pisał pierwszy kod maszynowy w 1946 roku. Respektowanie tych zasad to warunek, że uzyska się oprogramowanie o czystej architekturze, czyli poprawne strukturalnie, łatwe w utrzymaniu i rozwijaniu, a przede wszystkim działające zgodnie z oczekiwaniami.\r\n\r\nW tej książce w sposób jasny i bardzo interesujący przedstawiono uniwersalne zasady architektury oprogramowania wraz z szeregiem wskazówek dotyczących stosowania tych reguł w praktyce. Wyczerpująco zaprezentowano tu dostępne rozwiązania i wyjaśniono, dlaczego są one tak istotne dla sukcesu przedsięwzięcia. Publikacja jest wypełniona bardzo praktycznymi rozwiązaniami problemów, z którymi musi się mierzyć wielu programistów. Szczególnie cenne są uwagi dotyczące zapobiegania częstemu problemowi, jakim jest stopniowa utrata jakości kodu w miarę postępu projektu. Ta książka obowiązkowo powinna się znaleźć w podręcznej biblioteczce każdego architekta oprogramowania, analityka systemowego, projektanta i menedżera!",
                        ImgPath = "aa18da53d1b1f4c45a0aa8dc88b19215.jpg",
                        Price = 129,
                        UserScore = 4.3,
                        Published = new DateTime(2017,02,01),
                        IsRecommended = true,
                        IsOnLimitedSale = false,
                        LimitedSalePrice = 99,
                        NumberOfPages = 329,
                        DiscountedPrice = 119
                    },
                    new Book()
                    {
                        Name = "Java. Efektywne programowanie.",
                        Description = "Język Java jest konsekwentnie udoskonalany i unowocześniany dzięki zaangażowaniu wielu ludzi. Nowoczesny język Java staje się coraz bardziej wieloparadygmatowy, co oznacza, że stosowanie najlepszych praktyk w coraz większym stopniu determinuje jakość kodu. Obecnie napisanie kodu, który prawidłowo działa i może być łatwo zrozumiany przez innych programistów, nie wystarczy - należy zbudować program w taki sposób, aby można było go łatwo modyfikować. Jako że Java stała się obszerną i złożoną platformą, konieczne stało się uaktualnienie najlepszych praktyk.\r\n\r\nTa książka jest kolejnym, trzecim wydaniem klasycznego podręcznika programowania w Javie. Poszczególne rozdziały zostały gruntownie przejrzane, zaktualizowane i wzbogacone o sporo ważnych treści. Znalazło się tu wiele wartościowych porad dotyczących organizowania kodu w taki sposób, aby stał się przejrzysty, co ułatwi przyszłe modyfikacje i usprawnienia. Poza takimi zagadnieniami, jak programowanie zorientowane obiektowo czy korzystanie z różnych typów, obszernie omówiono stosowanie lambd i strumieni, zasady obsługi wyjątków, korzystania ze współbieżności i serializacji. Książka składa się z dziewięćdziesięciu tematów pogrupowanych w dwanaście rozdziałów. Taki układ pozwala na szybkie odnalezienie potrzebnego rozwiązania.",
                        ImgPath = "a012c527dfb69539eee025114bdc7b32,javep3.jpg",
                        Price = 179,
                        UserScore = 4.8,
                        Published = new DateTime(2017,02,01),
                        IsRecommended = true,
                        IsOnLimitedSale = true,
                        LimitedSalePrice = 149,
                        NumberOfPages = 421,
                        DiscountedPrice = 159
                    },
                    new Book()
                    {
                        Name = "Algorytmy. Wydanie IV",
                        Description = "Algorytmy od zawsze porównywane były do przepisów kucharskich. Z celnością tego porównania trudno dyskutować, na pewno jednak przesolenie zupy ma zupełnie inne konsekwencje niż błędnie opracowany lub zaimplementowany algorytm. To właśnie algorytmy decydują o czasie wykonania skomplikowanych operacji przez programy komputerowe, a ich odpowiednia implementacja może niejednokrotnie decydować o sukcesie lub porażce projektu wartego fortunę.\r\n\r\nDzięki tej książce masz szansę uniknąć typowych programistycznych błędów i porażek. Jej lektura zapozna Cię z najpopularniejszymi algorytmami, ich licznymi zaletami oraz słabymi stronami. Sprawdzisz, do czego można je zastosować, a w jakich miejscach lepiej zrezygnować z ich wykorzystania. Ponadto nauczysz się analizować działanie algorytmów, mierzyć ich wydajność oraz dobierać dane testowe. W książce zostały omówione klasyczne algorytmy sortowania, wyszukiwania, operacji na grafach oraz kompresji danych. Jej ogromnym atutem są przykładowe implementacje algorytmów w języku JAVA oraz to, że przedstawiony kod jest gotowy do natychmiastowego użycia! Pozycja ta jest obowiązkową lekturą dla każdego programisty, któremu zależy na najwyższej wydajności tworzonych rozwiązań.",
                        ImgPath = "64f206fef9803cd9be8ea78c11dbbc3f,algo4v.jpg",
                        Price = 169,
                        UserScore = 5,
                        Published = new DateTime(2019,02,01),
                        IsRecommended = true,
                        IsOnLimitedSale = false,
                        LimitedSalePrice = 139,
                        NumberOfPages = 342,
                        DiscountedPrice = 159
                    }
                };
            _ctx.Books.AddRange(books);

            var categories = new List<Category>()
            {
                new Category(){Name = "Programming"},
                new Category(){Name = "History"},
                new Category(){Name = "Fiction"},
                new Category(){Name = "Fantasy"},
                new Category(){Name = "Comics"},
                new Category(){Name = "Food & Cooking"},
                new Category(){Name = "Biography"},
                new Category(){Name = "Religion"},
                new Category(){Name = "Science"},
            };
            _ctx.Categories.AddRange(categories);

            _ctx.SaveChanges();
        }
    }
}
