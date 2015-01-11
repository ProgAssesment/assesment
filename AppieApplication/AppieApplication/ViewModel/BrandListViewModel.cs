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
    public class BrandListViewModel : ViewModelBase
    {

        private IBrandRepository repo;
        private IRecipeRepository recipo;

        private BrandViewModel selectedBrand;

        private ObservableCollection<BrandViewModel> brands;

        private String brandName;

        private double brandPrice;

        private int productId;

        public String BrandName { get { return brandName; } set { brandName = value; RaisePropertyChanged(); } }

        public double BrandPrice { get { return brandPrice; } set { brandPrice = value; RaisePropertyChanged(); } }

        public BrandViewModel SelectedBrand { get { return selectedBrand; } set { selectedBrand = value; RaisePropertyChanged(); } }

        public ObservableCollection<BrandViewModel> Brands { get { return brands; } set { brands = value; RaisePropertyChanged(); } }

        public ICommand DeleteBrandCommand { get; set; }
        public ICommand EditBrandCommand { get; set; }
        public ICommand AddBrandCommand { get; set; }

        public ICommand AddToShoppingListCommand { get; set; }

        public BrandListViewModel(IBrandRepository repo)
        {
            //dependency injecteren
            //this.recipo = recipo;

            this.repo = repo;
            var brandList = repo.GetAll().Select(b => new BrandViewModel(b));
            Brands = new ObservableCollection<BrandViewModel>(brandList);
            Messenger.Default.Register<NotificationMessage<int>>(this, OnHitIt);

            DeleteBrandCommand = new RelayCommand(DeleteBrand, CanDeleteBrand);
            AddBrandCommand = new RelayCommand(AddBrand, CanAddBrand);
            EditBrandCommand = new RelayCommand(EditBrand, CanEditBrand);
            AddToShoppingListCommand = new RelayCommand(AddToShoppingList, CanAddToShoppingList);
        }

        public bool CanAddBrand()
        {
            return brandName != null && brandPrice != 0;
        }

        public void AddBrand()
        {

            BrandViewModel bvm = new BrandViewModel();
            bvm.Name = brandName;
            bvm.Price = brandPrice;

            Brand b = new Brand();
            b.Name = bvm.Name;
            b.ProductId = productId;
            b.Price = bvm.Price;

            repo.Create(b);
            bvm.Id = repo.GetByName(b.Name).id;

            Brands.Add(bvm);

            

        }

        public bool CanAddToShoppingList()
        {
            return SelectedBrand != null;
        }

        public void AddToShoppingList()
        {
            Brand b = repo.Get(selectedBrand.Id);
            repo.AddToShoppingList(b);
        }

        public bool CanEditBrand()
        {
            return SelectedBrand != null;
        }

        public void EditBrand()
        {
            Brand b = repo.Get(selectedBrand.Id);
            b.Name = selectedBrand.Name;
            b.Price = selectedBrand.Price;

            repo.Edit(b);
        }

        public bool CanDeleteBrand()
        {
            return SelectedBrand != null;
        }

        public void DeleteBrand()
        {
            Brand b = repo.Get(selectedBrand.Id);
            repo.Delete(b);

            Brands.Remove(selectedBrand);

            SelectedBrand = new BrandViewModel();

        }

        private void OnHitIt(NotificationMessage<int> m)
        {
            if (m.Notification == "product")
            {
                productId = m.Content;
                var brandList = repo.GetAll().Where(x => x.ProductId.Equals(productId)).Select(b => new BrandViewModel(b));
                Brands = new ObservableCollection<BrandViewModel>(brandList);
            }

            if (m.Notification == "recipe")
            {
                
                var recept = recipo.GetAll().Where(x => x.id.Equals(m.Content)).First();
                var list = recept.Products.Select(b => new BrandViewModel(b));
                
                Brands = new ObservableCollection<BrandViewModel>(list);

            }
          
        }
    }
}
