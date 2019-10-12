using jrlgreetings.Core.Services;
using MvvmCross.Navigation;
using System.Text;

namespace jrlgreetings.Core.ViewModels
{
    public class NorthEastViewModel : BaseViewModel
    {
        public NorthEastViewModel(IRoomDataService roomDataService, IMvxNavigationService navigationService)
            : base(2, roomDataService, navigationService)
        {
        }

        protected override void OnAnnoyanceFactorChanged()
        {
            RaisePropertyChanged(nameof(RoomContentText));
        }

        public override string RoomContentText
        {
            get
            {
                if (AnnoyanceFactor < 0.5)
                    return thisRoom.ContentText;

                StringBuilder sb = new StringBuilder();
                foreach (char c in thisRoom.ContentText)
                {
                    if (char.IsWhiteSpace(c))
                        sb.Append(c);
                    else
                    {
                        byte b = (byte)((byte)c ^ (byte)((annoyanceFactor * 0.96) + 32));
                        sb.Append((char)b);
                    }
                }

                return sb.ToString();
            }
        }
    }
}
