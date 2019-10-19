using jrlgreetings.Core.Models;
using jrlgreetings.Core.ViewModels;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvvmCross;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jrlgreetings.Core.Services
{
    public abstract class BaseRoomDataService : IRoomDataService
    {
        protected readonly Dictionary<int, Room> rooms = new Dictionary<int, Room>();
        protected readonly IMvxViewModel[] ViewModels = new IMvxViewModel[10];
        protected readonly List<IMvxViewModel> Flashbacks = new List<IMvxViewModel>();

        protected bool isReady = false;
        public bool IsReady => isReady;

        public abstract Task InitAsync();

        protected void setViewModels()
        {
            ViewModels[0] = new NorthWestViewModel(this, Mvx.IoCProvider.Resolve<IMvxNavigationService>());
            ViewModels[1] = new NorthViewModel(this, Mvx.IoCProvider.Resolve<IMvxNavigationService>());
            ViewModels[2] = new NorthEastViewModel(this, Mvx.IoCProvider.Resolve<IMvxNavigationService>());
            ViewModels[3] = new WestViewModel(this, Mvx.IoCProvider.Resolve<IMvxNavigationService>());
            ViewModels[4] = new CentralViewModel(this, Mvx.IoCProvider.Resolve<IMvxNavigationService>());
            ViewModels[5] = new EastViewModel(this, Mvx.IoCProvider.Resolve<IMvxNavigationService>());
            ViewModels[6] = new SouthWestViewModel(this, Mvx.IoCProvider.Resolve<IMvxNavigationService>());
            ViewModels[7] = new SouthViewModel(this, Mvx.IoCProvider.Resolve<IMvxNavigationService>());
            ViewModels[8] = new SouthEastViewModel(this, Mvx.IoCProvider.Resolve<IMvxNavigationService>());
            ViewModels[9] = new ExceptionalViewModel(this, Mvx.IoCProvider.Resolve<IMvxNavigationService>());
        }

        protected void makeLocalRooms()
        {
            rooms[0] = new Room()
            {
                RoomNo = 0,
                Description = "The world is a drab and colorless place. In a quest for colors you have come to this Temple of Colors, and entered it to the North West. But even here all seems grey.\n\n" +
                "This room is boring, but for what might be an inscription.\n\n" +
                "There is a lever at the bottom of the wall.",
                ContentText = "Hello there!\n\n" +
                "Please allow me to introduce myself, my name is Jon Robinson Levy.\n\n" +
                "This app is a small presentation of me, and hopefully shows a few skills, while being entertaining and untraditional. It is not supposed to be beautiful - you hopefully have designers for that.\n\n" +
                "You will learn more about me & the app in the other rooms — if you overcome the challenges. (It shouldn't be that difficult, though.)",
            };
            rooms[1] = new Room()
            {
                RoomNo = 1,
                Description = "What is this devilry, letters hanging in the air? They are hard to make out.\n\n" +
                "There is a lever near the floor.",
                ContentText = "I learned programming many years ago, by my father, at the same time he was introduced to it. On a mainframe computer; the year was 1980, the language was Fortran, and I was 11.\n\n" +
                "It was also then I first met the Colossal Adventure game. To cheat and solve the riddles I looked at the source code, which was in Pascal (and I more or less learned Pascal that way.) And that was the first taste of what would become another lifelong companion: Dungeons & Dragons. (And I guess this App is a sort of hat tip to a@dven.ture, as the game was called on the Sperry Univac mainframe).\n\n" +
                "After learning programming, the next steps were getting a computer at home, which was at first a ZX81, then a ZX Spectrum, until we got our first PC — and I eventually started programming in C."
            };
            rooms[2] = new Room()
            {
                RoomNo = 2,
                Description = "You are in a room to the North East of the temple. There is an inscription, but it doesn't make sense at all.\n\n" +
                "There is a lever on the wall near the floor.",
                ContentText = "I landed my first job programming when I was 19, with som help from my dad. After that I got to DSB, where I worked in COBOL on their mainframe for a number of years. After a short adventure trying to make an adventure game, I was at Rigshospitalet for 5 years (my former boss at DSB had gone there.)\n\n" +
                "In 2000 I finally got a job doing C++ (which I had been using in my spare time since the early nineties), designing and programming a CMS. The CMS had limited success, and the company couldn't get capital after the dotcom-bust, but I did jobs for the CEO for a number of years."
            };
            rooms[3] = new Room()
            {
                RoomNo = 3,
                Description = "There is an inscription in this room, but it just makes you crosseyed, and makes no sense.\n\n" +
                "There is a lever near your feet.",
                ContentText = "I learned C# and .Net in 2007, and that is what I have been using since; I find it liberating not having to think about memory and pointer allocations all the time, although my younger self would probably scoff at me.\n\n" +
                "With .Net I have been doing most kinds of things, I believe, starting with ASP.Net (Web Forms, later MVC), then web services, APIs and background jobs."
            };
            rooms[4] = new Room()
            {
                RoomNo = 4,
                Description = "You are in the center of the Temple. On the wall are strange contraptions, that seems to have to do with numbers.\n\n" +
                "You have heard rumors of this room — it is said it can take you to an exceptional room, but first you have to become exceptional yourself.\n\n" +
                "The lever near the floor is connected to the numbers, somehow.",
                ContentText = "The first time I made an app it was just to try it out; it was Android & Java, and probably around 2011. It wasn't until a few years later I did anything serious.\n\n" +
                "At that time I was working on a bigger project related to Twitter. It was mainly a web site, but I wanted apps for it as well. As I was working in C# and .Net it seemed it would be simplest to start with an app for Windows Phone, even if the market wasn't big. So I started with Silverlight/Windows Phone 8.\n\n" +
                "And I discovered I liked working with Apps, it was a bit like coming 'home' to the early days, on the ZX Spectrum and early PCs. Even though much was changed, of course."
            };
            rooms[5] = new Room()
            {
                RoomNo = 5,
                Description = "You gasp as letters swirl around you — 'Make them stop!' you exclaim. Then you see the lever near the floor.",
                ContentText = "I continued working with apps, and I also stayed with Windows and Windows Phone, through the RT days to UWP. But while I liked the platform more and more it was also clearer and clearer that the market would never become big. So I got increasingly interested in checking out Xamarin.\n\n" +
                "But Xamarin was expensive. So it wasn't until Microsoft acquired it, that I really started looking into it, and started playing with it — Xamarin Forms, that is.\n\n" +
                "And I have discovered that I like it perhaps even more than UWP. I like the intellectual challenge of splitting the App into abstractions of what can be shared, and the diversity in implementing the abstractions natively. And I like MVVM."
            };
            rooms[6] = new Room()
            {
                RoomNo = 6,
                Description = "This room in the South West part of the Temple seems even more drab than the others. There aren't even any inscriptions, it seems.\n\n" +
                "There's a lever, but that is hardly interesting.",
                ContentText = "So even while I also like to work with back ends and Databases, I came to conclusion that I wanted to do more with Xamarin, and in February I did the certifications (after discovering you didn't have to sign up for a year anymore, but could do it within a month. I ended up doing it in 12 days.)\n\n"
            };
            rooms[7] = new Room()
            {
                RoomNo = 7,
                Description = "Finally some colors, seven colored veils swirl in this room. However they prevent you from seeing the wall. Is there an inscription?\n\n" +
                "There's a lever near the floor, below the veils.",
                ContentText = "I have a lot of experience, doing all kinds of coding, and I'm still good at learning stuff, I believe. At the same time I have a knack for understanding and remembering complex systems, so I usually have a good idea about what happens where.\n\n" +
                "I am not good at graphical design, though. I can place things, but if you want it to look good, you need to tell me how it should look."
            };
            rooms[8] = new Room()
            {
                RoomNo = 8,
                Description = "You are in the South East of the temple, as far from the entrance as you can get. The inscription almost seems to make sense, but then it turns out it doesn't. Is it some kind of code?\n\n" +
                "Theres a lever at the bottom of the wall.",
                ContentText = "So why aren't you hiring me?\n\n" +
                "Well, a likely reason is that I have been working solo for a number of years, now. When I was last employed I became ill with a depression, which ended with me quitting, as I didn't feel I was delivering what I ought to. Shortly there after my mother became ill with cancer, and I had to take care of her while the disease ran it's course.\n\n" +
                "After she died I needed to find myself again, for myself — and I needed to find my joy of programming. As I also inherited some money I had the opportunity to do that.\n\n" +
                "Which I have - found myself & my joy of programming. And now I want to be part of something again. But seems the years for my self has made people skeptical of my abilities & skills.\n\n" +
                "Therefore I'm willing to start at a reduced rate — I might even give you a month free of charge, if the job you offer is interesting enough — or some other arrangement. I am doing that, as I am confident it will be beneficial for both parties in the long run — and I don't doubt my own abilities, and am quite confident you will be satisfied and want to hire me."
            };
            rooms[9] = new Room()
            {
                RoomNo = 9,
                Description = "With a crack of thunder you teleport to this Exceptional Room. On the wall are stones with numbers that seems to be part of some mechanism.\n\n" +
                "Below the stones you find a lever.",
                ContentText = "About this App\n\n" +
                "It is made in Xamarin Forms, at this point only published for Android and UWP (I won't pay Apple's exorbitant price to publish in their store). Basically it's some fun with converters.\n\n" +
                "I'm not claiming it's particularly ingenious, but I hope it's enough to show that I know what Xamarin is about.\n\n" +
                "It's also my first app (except for the tutorial TipCalc) that I have made using MvvmCross. As I would like to do more in Xamarin Native, but also stay with MVVM and it's possibilities for code re-use, MvvmCross seems an interesting way to explore.\n\n" +
                "I originally made the app for a particular job, to impress the people at that company; and apparently it worked as they did hire me. Almost. As it happened it fell through, due to in-house problems.\n\n" +
                "So this version is a more general version of that one. I may add other platforms over time." +
                "Anyways, I hope you enjoyed the app — and got some impression of me…!\n\n" +
                "Best regards,\n" +
                "Jon"
            };
        }

        public Room GetRoomForRoomNo(int roomNo) => rooms[roomNo];

        public int Completed => rooms.Values.Where(r => r.Completed == true).Count();
        public int UnCompleted => rooms.Values.Where(r => r.Completed == false).Count();
        public IMvxViewModel GetViewModelForRoomNo(int roomNo) => ViewModels[roomNo];
        public IEnumerable<bool> RoomCompletionInfo => rooms.Values.OrderBy(r => r.RoomNo).Select(r => r.Completed);

        int currentLocation = 0;
        public int CurrentLocation => currentLocation;
        public IMvxViewModel CurrentLocationViewModel => GetViewModelForRoomNo(this.currentLocation);

        public bool CanGoNorth => currentLocation == 9 ? false : currentLocation > 2;
        public bool CanGoWest => currentLocation == 9 ? false : currentLocation % 3 > 0;
        public bool CanGoEast => currentLocation == 9 ? false : currentLocation % 3 < 2;
        public bool CanGoSouth => currentLocation == 9 ? false : currentLocation < 6;

        public Task GoNorthAsync() => GoToRoomNoAsync(currentLocation - 3);
        public Task GoWestAsync() => GoToRoomNoAsync(currentLocation - 1);
        public Task GoSouthAsync() => GoToRoomNoAsync(currentLocation + 3);
        public Task GoEastAsync() => GoToRoomNoAsync(currentLocation + 1);
        public async Task GoToRoomNoAsync(int destinationRoomNo)
        {
            if (currentLocation != destinationRoomNo)
            {
                if (currentLocation == 9 || destinationRoomNo == 9)
                    Mvx.IoCProvider.Resolve<ISoundPlayerService>().PlayThunder();
                else
                    Mvx.IoCProvider.Resolve<ISoundPlayerService>().PlayFootsteps();

                await Task.Delay(500);
            }
            await Mvx.IoCProvider.Resolve<IMvxNavigationService>().Navigate(GetViewModelForRoomNo(destinationRoomNo));
            currentLocation = destinationRoomNo;
            CurrentLocationChanged?.Invoke(this, new EventArgs());
        }

        public Task<bool> MarkRoomCompleted(int roomNo)
        {
            bool notAlreadyCompleted = !rooms[roomNo].Completed;
            if (notAlreadyCompleted)
            {
                rooms[roomNo].Completed = true;
                if (this.UnCompleted == 0)
                {
                    Mvx.IoCProvider.Resolve<ISoundPlayerService>().PlayFireworks();
                    TempleIsCompleted?.Invoke(this, new EventArgs());
                }
                return Task.FromResult<bool>(true);
            }
            else
                return Task.FromResult<bool>(false);
        }

        public event EventHandler CurrentLocationChanged;
        public event EventHandler TempleIsCompleted;
    }
}
