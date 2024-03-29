﻿using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using PolynomialCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialAppUI
{
    class MainWindowDataContext : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private Polynomial? _polynomial;
        
        public Polynomial? Polynomial
        {
            get
            {
                return _polynomial;
            }
            set
            {
                _polynomial = value;
                OnPropertyChanged();
            }
        }

        private string _polynomialFormula = "";

        public string PolynomialFormula
        {
            get
            {
                return _polynomialFormula;
            }
            set
            {
                _polynomialFormula = value;
                OnPropertyChanged();
            }
        }

        private Polynomial? _secondPolynomial;

        public Polynomial? SecondPolynomial
        {
            get
            {
                return _secondPolynomial;
            }
            set
            {
                _secondPolynomial = value;
                OnPropertyChanged();
            }
        }

        private string _secondPolynomialFormula = "";

        public string SecondPolynomialFormula
        {
            get
            {
                return _secondPolynomialFormula;
            }
            set
            {
                _secondPolynomialFormula = value;
                OnPropertyChanged();
            }
        }

        private string _rest = "";

        public string Rest
        {
            get
            {
                return _rest;
            }
            set
            {
                _rest = value;
                OnPropertyChanged();
            }
        }

        private string _exceptionMessage = "";

        public string ExceptionMessage
        {
            get
            {
                return _exceptionMessage;
            }
            set
            {
                _exceptionMessage = value;
                OnPropertyChanged();
            }
        }

        private ISeries[] _series = { new LineSeries<ObservablePoint>()};

        public ISeries[] Series
        {
            get
            {
                return _series;
            }
            set
            {
                _series = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
