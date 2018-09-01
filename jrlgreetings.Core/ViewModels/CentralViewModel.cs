using jrlgreetings.Core.Services;
using MvvmCross.Core.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jrlgreetings.Core.ViewModels
{
    class CentralViewModel : BaseViewModel
    {
        public CentralViewModel(IRoomDataService roomDataService, ISoundPlayerService soundPlayerService, IMvxNavigationService navigationService)
            : base(4, roomDataService, soundPlayerService, navigationService)
        {

        }

        int operandMax = 30;
        public int OperandMax
        {
            get => operandMax;
            set => SetProperty(ref operandMax, value);
        }

        int operandMin = 10;
        public int OperandMin
        {
            get => operandMin;
            set => SetProperty(ref operandMin, value);
        }

        private int operand1 = 10;
        public int Operand1
        {
            get => operand1;
            set
            {
                if (SetProperty(ref operand1, value))
                    calcResult();
            }
        }

        private int operand2 = 10;
        public int Operand2
        {
            get => operand2;
            set
            {
                if (SetProperty(ref operand2, value))
                    calcResult();
            }
        }

        public override void ViewAppearing()
        {
            base.ViewAppearing();
            OnAnnoyanceFactorChanged();
        }

        protected override void OnAnnoyanceFactorChanged()
        {
            OperandMax = (int)(AnnoyanceFactor / 10.0) + 20;
            OperandMin = (int)(AnnoyanceFactor / 10.0);

            if (Operand1 < OperandMin)
                Operand1 = OperandMin;
            else if (Operand1 > OperandMax)
                Operand1 = OperandMax;

            if (Operand2 < OperandMin)
                Operand2 = OperandMin;
            else if (Operand2 > OperandMax)
                Operand2 = OperandMax;
        }

        readonly List<string> operators = new List<string>() { "+", "-", "*", "/" };
        public List<String> Operators => operators;

        private int selectedOperatorIndex = 0;
        public int SelectedOperatorIndex
        {
            get => selectedOperatorIndex;
            set
            {
                if (SetProperty(ref selectedOperatorIndex, value))
                    calcResult();
            }
        }

        char selectedOperator => Operators[SelectedOperatorIndex][0];

        async void calcResult()
        {
            try
            {
                switch (selectedOperator)
                {
                    case '+':
                        result = operand1 + operand2;
                        break;
                    case '-':
                        result = operand1 - operand2;
                        break;
                    case '*':
                        result = operand1 * operand2;
                        break;
                    case '/':
                        result = operand1 / operand2;
                        break;
                }
            }
            catch (Exception)
            {
                operand1 = 10;
                operand2 = 10;
                selectedOperatorIndex = 0;
                result = 20;
                await goToRoomNoAsync(9);
                RaisePropertyChanged(nameof(Operand2));
                RaisePropertyChanged(nameof(Operand1));
                RaisePropertyChanged(nameof(SelectedOperatorIndex));
            }
            finally
            {
                RaisePropertyChanged(nameof(Result));
            }
        }

        private double result = 20;
        public double Result => result;
    }
}
