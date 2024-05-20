﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Shared.Dtos;
using GroceryApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryApp.ViewModels
{
    public partial class CartViewModel : ObservableObject
    {
        public ObservableCollection<CartItem> CartItems { get; set; } = new();

        [ObservableProperty]
        private int _count;//The number of products we have in card

        [RelayCommand]
        private void AddToCart(ProductDto product)
        {
            var item = CartItems.FirstOrDefault(c => c.ProductId == product.Id);
            if (item is not null)
            {
                item.Quantity++;
            }
            else
            {
                item = new CartItem
                {
                    Id = Guid.NewGuid(),
                    ProductName = product.Name,
                    ProductId = product.Id,
                    Quantity = 1,
                    Price = product.Price,
                };
                CartItems.Add(item);
                Count = CartItems.Count;
            }
        }

        [RelayCommand]
        private void RemoveFromCart(int productId)
        {
            var item = CartItems.FirstOrDefault(c => c.ProductId == productId);
            if (item is not null)
            {
                if (item.Quantity == 1)
                {
                    CartItems.Remove(item);
                    Count = CartItems.Count;
                }
                else
                {
                    item.Quantity--;
                }
            }
        }

        private void ClearCart()
        {
            CartItems.Clear();
            Count = 0;
        }
    }
}
