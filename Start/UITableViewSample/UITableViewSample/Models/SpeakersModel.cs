﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UITableViewSample.Models
{
    public class SpeakersModel
    {
        #region PropertyChangedを使用する場合
        //public event PropertyChangedEventHandler PropertyChanged;

        //private bool _isBusy;
        //public bool IsBusy
        //{
        //    get { return _isBusy; }
        //    set
        //    {
        //        if (_isBusy != value)
        //        {
        //            _isBusy = value;
        //            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsBusy)));
        //        }
        //    }
        //}
        #endregion


        public SpeakersModel()
        {
        }

    }
}
