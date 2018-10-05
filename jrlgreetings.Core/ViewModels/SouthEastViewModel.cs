using jrlgreetings.Core.Services;
using MvvmCross.Navigation;
using System.Collections.Generic;
using System.Text;

namespace jrlgreetings.Core.ViewModels
{
    public class SouthEastViewModel : BaseViewModel
    {
        public SouthEastViewModel(IRoomDataService roomDataService, IMvxNavigationService navigationService)
            : base(8, roomDataService, navigationService)
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
                if (AnnoyanceFactor < .3)
                    return thisRoom.ContentText;

                int length = thisRoom.ContentText.Length;
                int segmentLength = (int)(length / (AnnoyanceFactor + 1.0));
                if (segmentLength < 2)
                    segmentLength = 2;

                List<string> segments = new List<string>();

                int idx = 0;
                while (idx < length)
                {
                    if (segmentLength + idx > length)
                        segmentLength = length - idx;

                    segments.Insert(0, thisRoom.ContentText.Substring(idx, segmentLength));
                    idx += segmentLength;
                }

                StringBuilder sb = new StringBuilder();
                foreach (string s in segments)
                    sb.Append(s);

                return sb.ToString(); 
            }
        }

    }
}
