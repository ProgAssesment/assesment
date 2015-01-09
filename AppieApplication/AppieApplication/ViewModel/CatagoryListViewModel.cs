﻿using AppieApplication.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppieApplication.ViewModel
{
    public class CatagoryListViewModel : ViewModelBase
    {

        private ProductsWindow productsWindow;
        private ICatagoryRepository repo;

        private String catagoryName;

        private CatagoryViewModel selectedCatagory;

        public CatagoryViewModel SelectedCatagory { get { return selectedCatagory; } set { selectedCatagory = value; RaisePropertyChanged(); } }

        public ObservableCollection<CatagoryViewModel> Catagories { get; set; }

        public String CatagoryName { get { return catagoryName; } set { catagoryName = value; RaisePropertyChanged(); } }

        public ICommand AddCatagoryCommand { get; set; }

        public ICommand EditCatagoryCommand { get; set; }

        public ICommand DeleteCatagoryCommand { get; set; }

        public ICommand OpenProductsWindowCommand { get; set; }

        public CatagoryListViewModel(ICatagoryRepository repo)
        {

            this.repo = repo;
            var catagoryList = repo.GetAll().Select(c => new CatagoryViewModel(c));
            Catagories = new ObservableCollection<CatagoryViewModel>(catagoryList);

            productsWindow = new ProductsWindow();
            AddCatagoryCommand = new RelayCommand(AddCatagory, CanAddCatagory);
            EditCatagoryCommand = new RelayCommand(EditCatagory, CanEditCatagory);
            DeleteCatagoryCommand = new RelayCommand(DeleteCatagory, CanDeleteCatagory);
            OpenProductsWindowCommand = new RelayCommand(OpenProductsWindow, CanOpenProductsWindow);
        }

        public bool CanOpenProductsWindow()
        {

            if (selectedCatagory != null)
            {
                return true;
            }

            return false;
        }

        public void OpenProductsWindow()
        {
            productsWindow = new ProductsWindow();
            Messenger.Default.Send(new NotificationMessage<int>(SelectedCatagory.Id, "catagory"));
            productsWindow.Show();
        }

        //Code toevoegen
        public bool CanAddCatagory()
        {
            return catagoryName != null;
        }

        public void AddCatagory()
        {

            CatagoryViewModel cvm = new CatagoryViewModel();
            cvm.Name = catagoryName;

            Catagory c = new Catagory();
            c.Name = cvm.Name;

            repo.Create(c);
            cvm.Id = repo.GetByName(c.Name).Id;

            Catagories.Add(cvm);
        }

        public bool CanEditCatagory()
        {
            return SelectedCatagory != null;
        }

        public void EditCatagory()
        {
            Catagory c = repo.Get(selectedCatagory.Id);
            c.Name = selectedCatagory.Name;

            repo.Edit(c);
        }


        public bool CanDeleteCatagory()
        {
            //if (SelectedCatagory != null)
            //{
            //    return true;
            //}

            return SelectedCatagory != null;
        }

        public void DeleteCatagory()
        {
            Catagory c = repo.Get(selectedCatagory.Id);
            repo.Delete(c);
            Catagories.Remove(selectedCatagory);
            SelectedCatagory = new CatagoryViewModel();
        }

    }
}
