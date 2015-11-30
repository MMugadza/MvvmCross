using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Droid.Support.Fragging.Fragments;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Binding.BindingContext;

namespace Cirrious.MvvmCross.Droid.Support.Preference
{
    public abstract class MvxPreferenceFragmentCompat : MvxEventSourcePreferenceFragmentCompat, IMvxFragmentView
    {
        protected MvxPreferenceFragmentCompat()
        {
            this.AddEventListeners();
        }

        protected MvxPreferenceFragmentCompat(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
            this.AddEventListeners();
        }

        public IMvxBindingContext BindingContext { get; set; }

        private object _dataContext;

        public object DataContext
        {
            get { return _dataContext; }
            set
            {
                _dataContext = value;
                if (BindingContext != null)
                    BindingContext.DataContext = value;
            }
        }

        public virtual IMvxViewModel ViewModel
        {
            get { return DataContext as IMvxViewModel; }
            set
            {
                DataContext = value;
                OnViewModelSet();
            }
        }

        public virtual void OnViewModelSet()
        {
        }

        public string UniqueImmutableCacheTag => Tag;
    }

    public abstract class MvxPreferenceFragmentCompat<TViewModel>
        : MvxPreferenceFragment
    , IMvxFragmentView<TViewModel> where TViewModel : class, IMvxViewModel
    {

        protected MvxPreferenceFragmentCompat()
        {

        }

        protected MvxPreferenceFragmentCompat(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer) { }


        public new TViewModel ViewModel
        {
            get { return (TViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }
    }
}
}