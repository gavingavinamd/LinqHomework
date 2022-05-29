using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private static readonly List<Athlete> _athelete = new List<Athlete>()
        {
            new Athlete{Medal="金牌", Name="郭婞淳", Sport="舉重", PrizeMoney=20000000 },
            new Athlete{Medal="金牌", Name="李洋、王齊麟", Sport="羽球", PrizeMoney=20000000 },
            new Athlete{Medal="銀牌", Name="楊勇緯", Sport="柔道", PrizeMoney=7000000 },
            new Athlete{Medal="銀牌", Name="鄧宇成、湯智鈞、魏均珩", Sport="射箭", PrizeMoney=7000000 },
            new Athlete{Medal="銀牌", Name="李智凱", Sport="體操", PrizeMoney=7000000 },
            new Athlete{Medal="銀牌", Name="戴資穎", Sport="羽球", PrizeMoney=7000000 },
            new Athlete{Medal="銅牌", Name="羅嘉翎", Sport="跆拳道", PrizeMoney=5000000 },
            new Athlete{Medal="銅牌", Name="林昀儒、鄭怡靜", Sport="桌球", PrizeMoney=5000000 },
            new Athlete{Medal="銅牌", Name="陳玟卉", Sport="舉重", PrizeMoney=5000000 },
            new Athlete{Medal="銅牌", Name="潘政琮", Sport="高爾夫", PrizeMoney=5000000 },
            new Athlete{Medal="銅牌", Name="黃筱雯", Sport="拳擊", PrizeMoney=5000000 },
            new Athlete{Medal="銅牌", Name="文姿云", Sport="空手道", PrizeMoney=5000000 }
        };

        private static readonly List<Athelete02> _athelete02 = new List<Athelete02>()
        {
            new Athelete02{Name="郭婞淳", Sport="舉重"},
            new Athelete02{Name="李洋、王齊麟", Sport="羽球"},
            new Athelete02{Name="楊勇緯", Sport="柔道"},
            new Athelete02{Name="鄧宇成、湯智鈞、魏均珩", Sport="射箭"},
            new Athelete02{Name="李智凱", Sport="體操"},
            new Athelete02{Name="戴資穎", Sport="羽球"},
            new Athelete02{Name="羅嘉翎", Sport="跆拳道"},
            new Athelete02{Name="林昀儒、鄭怡靜", Sport="桌球"},
            new Athelete02{Name="陳玟卉", Sport="舉重"},
            new Athelete02{Name="潘政琮", Sport="高爾夫"},
            new Athelete02{Name="黃筱雯", Sport="拳擊"},
            new Athelete02{Name="文姿云", Sport="空手道"}
        };

        private static readonly List<Medal> _medal = new List<Medal>()
        {
            new Medal{Name="郭婞淳",Rank="金牌",Money=20000000},
            new Medal{Name="李洋、王齊麟",Rank="金牌",Money=20000000},
            new Medal{Name="楊勇緯",Rank="銀牌",Money=7000000},
            new Medal{Name="鄧宇成、湯智鈞、魏均珩",Rank="銀牌",Money=7000000},
            new Medal{Name="李智凱",Rank="銀牌",Money=7000000},
            new Medal{Name="戴資穎",Rank="銀牌",Money=7000000},
            new Medal{Name="羅嘉翎",Rank="銅牌",Money=5000000},
            new Medal{Name="林昀儒、鄭怡靜",Rank="銅牌",Money=5000000},
            new Medal{Name="陳玟卉",Rank="銅牌",Money=5000000},
            new Medal{Name="潘政琮",Rank="銅牌",Money=5000000},
            new Medal{Name="黃筱雯",Rank="銅牌",Money=5000000},
            new Medal{Name="文姿云",Rank="銅牌",Money=5000000}
        };


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult LinqHomework()
        {
            var allgoldMadel = _athelete.Where(x => x.Medal == "金牌");
            var badmintonMadel = _athelete.Where(x => x.Sport == "羽球");
            var orderMoney = _athelete.OrderBy(x => x.PrizeMoney);
            var maxMoney = _athelete.Max(x => x.PrizeMoney);
            var sumMoney = _athelete.Sum(x => x.PrizeMoney);

            var bmtMaxMoney = _athelete
                .Where(x => x.Sport == "羽球")
                .Sum(x => x.PrizeMoney);

            var silverSumMoney = _athelete
                .Where(x => x.Medal == "銀牌")
                .Sum(x => x.PrizeMoney);

            var joinresult =
                from people in _athelete02
                join madel in _medal
                on people.Name equals madel.Name
                select new
                {
                    AtheleteMedal = madel.Rank,
                    AtheleteName = people.Name,
                    AtheleteSport = people.Sport,
                    AtheleteMoney = madel.Money
                };
            var atheleteList = joinresult.ToList();



            return View();
        }
    }
}