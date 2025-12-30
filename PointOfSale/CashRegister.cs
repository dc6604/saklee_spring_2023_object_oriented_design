using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFlyingSaucer.Data;

namespace TheFlyingSaucer.PointOfSale
{
    /// <summary>
    /// View model for CashRegisterControl
    /// </summary>
    public class CashRegister: INotifyPropertyChanged
    {
        /// <summary>
        /// Property change event declared
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Property for the current order
        /// </summary>
        public Order CurrentOrder { get; init; }

        /// <summary>
        /// Property for the total
        /// </summary>
        public decimal Total
        {
            get { return CurrentOrder.Total; }
        }

        /// <summary>
        /// Property for the amount due
        /// </summary>
        public decimal AmountDue
        {
            get
            {
                return (Total - ((100m * HundredBillCount) + (50m * FiftyBillCount) + (20m * TwentyBillCount) + (10m * TenBillCount) + (5m * FiveBillCount) + (2m * TwoBillCount) + (1m * OneBillCount)
                    + (1m * DollarCoinCount) + (.5m * FiftyCoinCount) + (.25m * QuarterCount) + (.1m * DimeCount) + (.05m * NickelCount) + (.01m * PennyCount)));
            }
        }

        /// <summary>
        /// Property for the change
        /// </summary>
        public decimal Change
        {
            get
            {
                if (AmountDue >= 0) return 0.00m;
                else return _changeMade;
            }
        }

        /// <summary>
        /// Private field for changes already made
        /// </summary>
        private decimal _changeMade = 0m;

        /// <summary>
        /// Private backing field for the count of the bill hundred
        /// </summary>
        private uint _hundredBillCount = 0;

        /// <summary>
        /// Property for the count of the bill hundred
        /// </summary>
        public uint HundredBillCount 
        { 
            get { return _hundredBillCount; } 
            set
            {
                _hundredBillCount = value;
                CalculateChange();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AmountDue"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Change"));
            }
        }

        /// <summary>
        /// Private backing field for the count of the bill fifty
        /// </summary>
        private uint _fiftyBillCount = 0;

        /// <summary>
        /// Property for the count of the bill fifty
        /// </summary>
        public uint FiftyBillCount
        {
            get { return _fiftyBillCount; }
            set
            {
                _fiftyBillCount = value;
                CalculateChange();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AmountDue"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Change"));
            }
        }

        /// <summary>
        /// Private backing field for the count of the bill twenty
        /// </summary>
        private uint _twentyBillCount = 0;

        /// <summary>
        /// Property for the count of the bill twenty
        /// </summary>
        public uint TwentyBillCount
        {
            get { return _twentyBillCount; }
            set
            {
                _twentyBillCount = value;
                CalculateChange();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AmountDue"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Change"));
            }
        }

        /// <summary>
        /// Private backing field for the count of the bill ten
        /// </summary>
        private uint _tenBillCount = 0;

        /// <summary>
        /// Property for the count of the bill ten
        /// </summary>
        public uint TenBillCount
        {
            get { return _tenBillCount; }
            set
            {
                _tenBillCount = value;
                CalculateChange();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AmountDue"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Change"));
            }
        }

        /// <summary>
        /// Private backing field for the count of the bill five
        /// </summary>
        private uint _fiveBillCount = 0;

        /// <summary>
        /// Property for the count of the bill five
        /// </summary>
        public uint FiveBillCount
        {
            get { return _fiveBillCount; }
            set
            {
                _fiveBillCount = value;
                CalculateChange();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AmountDue"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Change"));
            }
        }

        /// <summary>
        /// Private backing field for the count of the bill two
        /// </summary>
        private uint _twoBillCount = 0;

        /// <summary>
        /// Property for the count of the bill two
        /// </summary>
        public uint TwoBillCount
        {
            get { return _twoBillCount; }
            set
            {
                _twoBillCount = value;
                CalculateChange();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AmountDue"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Change"));
            }
        }

        /// <summary>
        /// Private backing field for the count of the bill one
        /// </summary>
        private uint _oneBillCount = 0;

        /// <summary>
        /// Property for the count of the bill one
        /// </summary>
        public uint OneBillCount
        {
            get { return _oneBillCount; }
            set
            {
                _oneBillCount = value;
                CalculateChange();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AmountDue"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Change"));
            }
        }

        /// <summary>
        /// Private backing field for the count of the dollar coin
        /// </summary>
        private uint _dollarCoinCount = 0;

        /// <summary>
        /// Property for the count of the dollar coin
        /// </summary>
        public uint DollarCoinCount 
        { 
            get { return _dollarCoinCount; } 
            set
            {
                _dollarCoinCount = value;
                CalculateChange();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AmountDue"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Change"));
            } 
        }

        /// <summary>
        /// Private backing field for the count of the fifty coin
        /// </summary>
        private uint _fiftyCoinCount = 0;

        /// <summary>
        /// Property for the count of the coin fifty
        /// </summary>
        public uint FiftyCoinCount 
        { 
            get { return _fiftyCoinCount; } 
            set
            {
                _fiftyCoinCount = value;
                CalculateChange();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AmountDue"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Change"));
            }
        }

        /// <summary>
        /// Private backing field for the count of the quarter
        /// </summary>
        private uint _quarterCount = 0;

        /// <summary>
        /// Property for the count of the quarter
        /// </summary>
        public uint QuarterCount 
        { 
            get { return _quarterCount; }
            set
            {
                _quarterCount = value;
                CalculateChange();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AmountDue"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Change"));
            }
        }

        /// <summary>
        /// Private backing field for the count of the dime
        /// </summary>
        private uint _dimeCount = 0;

        /// <summary>
        /// Property for the count of the dime
        /// </summary>
        public uint DimeCount
        {
            get { return _dimeCount; }
            set
            {
                _dimeCount = value;
                CalculateChange();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AmountDue"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Change"));
            }
        }

        /// <summary>
        /// Private backing field for the count of the nickel
        /// </summary>
        private uint _nickelCount = 0;

        /// <summary>
        /// Property for the count of the nickel
        /// </summary>
        public uint NickelCount
        {
            get { return _nickelCount; }
            set
            {
                _nickelCount = value;
                CalculateChange();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AmountDue"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Change"));
            }
        }

        /// <summary>
        /// Private backing field for the count of the penny
        /// </summary>
        private uint _pennyCount = 0;

        /// <summary>
        /// Property for the count of the penny
        /// </summary>
        public uint PennyCount
        {
            get { return _pennyCount; }
            set
            {
                _pennyCount = value;
                CalculateChange();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AmountDue"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Change"));
            }
        }

        /// <summary>
        /// Property for the count of the change of hundred bill
        /// </summary>
        public uint HundredBillChange { get; set; }

        /// <summary>
        /// Property for the count of the change of fifty bill
        /// </summary>
        public uint FiftyBillChange { get; set; }

        /// <summary>
        /// Property for the count of the change of twenty bill
        /// </summary>
        public uint TwentyBillChange { get; set; }

        /// <summary>
        /// Property for the count of the change of ten bill
        /// </summary>
        public uint TenBillChange { get; set; }

        /// <summary>
        /// Property for the count of the change of five bill
        /// </summary>
        public uint FiveBillChange { get; set; }

        /// <summary>
        /// Property for the count of the change of two bill
        /// </summary>
        public uint TwoBillChange { get; set; }

        /// <summary>
        /// Property for the count of the change of one bill
        /// </summary>
        public uint OneBillChange { get; set; }

        /// <summary>
        /// Property for the count of the change of dollar coin
        /// </summary>
        public uint DollarCoinChange { get; set; }

        /// <summary>
        /// Property for the count of the change of fifty coin
        /// </summary>
        public uint FiftyCoinChange { get; set; }

        /// <summary>
        /// Property for the count of the change of quarter
        /// </summary>
        public uint QuarterChange { get; set; }

        /// <summary>
        /// Property for the count of the change of dime
        /// </summary>
        public uint DimeChange { get; set; }

        /// <summary>
        /// Property for the count of the change of nickel
        /// </summary>
        public uint NickelChange { get; set; }

        /// <summary>
        /// Property for the count of the change of penny
        /// </summary>
        public uint PennyChange { get; set; }

        /// <summary>
        /// Property for the total count of the hundred bill
        /// </summary>
        public uint HundredBillTotalCount
        {
            get { return RoundRegister.CashDrawer.Hundreds; }
            set { RoundRegister.CashDrawer.Hundreds = value; }
        }

        /// <summary>
        /// Property for the total count of the fifty bill
        /// </summary>
        public uint FiftyBillTotalCount
        {
            get { return RoundRegister.CashDrawer.Fifties; }
            set { RoundRegister.CashDrawer.Fifties = value; }
        }

        /// <summary>
        /// Property for the total count of the twenty bill
        /// </summary>
        public uint TwentyBillTotalCount
        {
            get { return RoundRegister.CashDrawer.Twenties; }
            set { RoundRegister.CashDrawer.Twenties = value; }
        }

        /// <summary>
        /// Property for the total count of the ten bill
        /// </summary>
        public uint TenBillTotalCount
        {
            get { return RoundRegister.CashDrawer.Tens; }
            set { RoundRegister.CashDrawer.Tens = value; }
        }

        /// <summary>
        /// Property for the total count of the five bill
        /// </summary>
        public uint FiveBillTotalCount
        {
            get { return RoundRegister.CashDrawer.Fives; }
            set { RoundRegister.CashDrawer.Fives = value; }
        }

        /// <summary>
        /// Property for the total count of the two bill
        /// </summary>
        public uint TwoBillTotalCount
        {
            get { return RoundRegister.CashDrawer.Twos; }
            set { RoundRegister.CashDrawer.Twos = value; }
        }

        /// <summary>
        /// Property for the total count of the one bill
        /// </summary>
        public uint OneBillTotalCount
        {
            get { return RoundRegister.CashDrawer.Ones; }
            set { RoundRegister.CashDrawer.Ones = value; }
        }

        /// <summary>
        /// Property for the total count of the dollar coin
        /// </summary>
        public uint DollarCoinTotalCount
        {
            get { return RoundRegister.CashDrawer.DollarCoins; }
            set { RoundRegister.CashDrawer.DollarCoins = value; }
        }

        /// <summary>
        /// Property for the total count of the fifty coin
        /// </summary>
        public uint FiftyCoinTotalCount
        {
            get { return RoundRegister.CashDrawer.HalfDollarCoins; }
            set { RoundRegister.CashDrawer.HalfDollarCoins = value; }
        }

        /// <summary>
        /// Property for the total count of the quarter
        /// </summary>
        public uint QuarterTotalCount
        {
            get { return RoundRegister.CashDrawer.Quarters; }
            set { RoundRegister.CashDrawer.Quarters = value; }
        }

        /// <summary>
        /// Property for the total count of the dime
        /// </summary>
        public uint DimeTotalCount
        {
            get { return RoundRegister.CashDrawer.Dimes; }
            set { RoundRegister.CashDrawer.Dimes = value; }
        }

        /// <summary>
        /// Property for the total count of the nickel
        /// </summary>
        public uint NickelTotalCount
        {
            get { return RoundRegister.CashDrawer.Nickles; }
            set { RoundRegister.CashDrawer.Nickles = value; }
        }

        /// <summary>
        /// Property for the total count of the penny
        /// </summary>
        public uint PennyTotalCount
        {
            get { return RoundRegister.CashDrawer.Pennies; }
            set { RoundRegister.CashDrawer.Pennies = value; }
        }

        /// <summary>
        /// Constructor for Cash register
        /// </summary>
        /// <param name="order">Current order</param>
        public CashRegister(Order order)
        {
            CurrentOrder = order;
        }

        /// <summary>
        /// Method to calculate how to give change
        /// </summary>
        public void CalculateChange()
        {
            decimal temp = 0m;
            if (AmountDue < 0)
            {
                temp = (AmountDue * (-1));
            }
            _changeMade = temp;
            HundredBillChange = 0;
            FiftyBillChange = 0;
            TwentyBillChange = 0;
            TenBillChange = 0;
            FiveBillChange = 0;
            TwoBillChange = 0;
            OneBillChange = 0;
            DollarCoinChange = 0;
            FiftyCoinChange = 0;
            QuarterChange = 0;
            DimeChange = 0;
            NickelChange = 0;
            PennyChange = 0;
            uint hundredbc = HundredBillTotalCount;
            uint fiftybc = FiftyBillTotalCount;
            uint twentybc = TwentyBillTotalCount;
            uint tenbc = TenBillTotalCount;
            uint fivebc = FiveBillTotalCount;
            uint twobc = TwoBillTotalCount;
            uint onebc = OneBillTotalCount;
            uint dollarcc = DollarCoinTotalCount;
            uint fiftycc = FiftyCoinTotalCount;
            uint qc = QuarterTotalCount;
            uint dc = DimeTotalCount;
            uint nc = NickelTotalCount;
            uint pc = PennyTotalCount;
            while (temp >= 100 && hundredbc > 0)
            {
                HundredBillChange++;
                hundredbc--;
                temp -= 100;
            }
            while (temp >= 50 && fiftybc > 0)
            {
                FiftyBillChange++;
                fiftybc--;
                temp -= 50;
            }
            while (temp >= 20 && twentybc > 0)
            {
                TwentyBillChange++;
                twentybc--;
                temp -= 20;
            }
            while (temp >= 10 && tenbc > 0)
            {
                TenBillChange++;
                tenbc--;
                temp -= 10;
            }
            while (temp >= 5 && fivebc > 0)
            {
                FiveBillChange++;
                fivebc--;
                temp -= 5;
            }
            while (temp >= 2 && twobc > 0)
            {
                TwoBillChange++;
                twobc--;
                temp -= 2;
            }
            while (temp >= 1 && onebc > 0)
            {
                OneBillChange++;
                onebc--;
                temp -= 1;
            }
            while (temp >= 1 && dollarcc > 0)
            {
                DollarCoinChange++;
                dollarcc--;
                temp -= 1;
            }
            while (temp >= 0.50m && fiftycc > 0)
            {
                FiftyCoinChange++;
                fiftycc--;
                temp -= 0.5m;
            }
            while (temp >= 0.25m && qc > 0)
            {
                QuarterChange++;
                qc--;
                temp -= 0.25m;
            }
            while (temp >= 0.10m && dc > 0)
            {
                DimeChange++;
                dc--;
                temp -= 0.10m;
            } while (temp >= 0.05m && nc > 0)
            {
                NickelChange++;
                nc--;
                temp -= 0.05m;
            }
            while (temp >= 0.01m && temp >= 0 && pc > 0)
            {
                PennyChange++;
                pc--;
                temp -= 0.01m;
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("HundredBillChange"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiftyBillChange"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TwentyBillChange"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TenBillChange"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiveBillChange"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TwoBillChange"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("OneBillChange"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DollarCoinChange"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiftyCoinChange"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("QuarterChange"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DimeChange"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NickelChange"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PennyChange"));
        }

        /// <summary>
        /// Method to finalize the changes to the count made
        /// </summary>
        public void FinalizeChange()
        {
            HundredBillTotalCount += HundredBillCount - HundredBillChange;
            FiftyBillTotalCount += FiftyBillCount - FiftyBillChange;
            TwentyBillTotalCount += TwentyBillCount - TwentyBillChange;
            TenBillTotalCount += TenBillCount - TenBillChange;
            FiveBillTotalCount += FiveBillCount - FiveBillChange;
            TwoBillTotalCount += TwoBillCount - TwoBillChange;
            OneBillTotalCount += OneBillCount - OneBillChange;
            DollarCoinTotalCount += DollarCoinCount - DollarCoinChange;
            FiftyCoinTotalCount += FiftyCoinCount - FiftyCoinChange;
            QuarterTotalCount += QuarterCount - QuarterChange;
            NickelTotalCount += NickelCount - NickelChange;
            PennyTotalCount += PennyCount - PennyChange;
        }
    }
}
