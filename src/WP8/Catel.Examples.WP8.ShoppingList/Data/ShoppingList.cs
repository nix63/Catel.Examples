﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShoppingList.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.WP8.ShoppingList.Data
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Catel.Data;

    /// <summary>
    /// ShoppingList Data object class which fully supports serialization, property changed notifications,
    /// backwards compatibility and error checking.
    /// </summary>
    public class ShoppingList : SavableModelBase<ShoppingList>, IShoppingList
    {
        #region Variables
        #endregion

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new object from scratch.
        /// </summary>
        public ShoppingList()
        {
            Items = new ObservableCollection<IShoppingListItem>();
        }
        #endregion

        #region Constants
        /// <summary>
        /// Register the DueDate property so it is known in the class.
        /// </summary>
        public static readonly PropertyData DueDateProperty = RegisterProperty("DueDate", typeof (DateTime), DateTime.Today);

        /// <summary>
        /// Register the Name property so it is known in the class.
        /// </summary>
        public static readonly PropertyData NameProperty = RegisterProperty("Name", typeof (string), string.Empty);

        /// <summary>
        /// Register the Shop property so it is known in the class.
        /// </summary>
        public static readonly PropertyData ShopProperty = RegisterProperty("Shop", typeof (IShop), null);

        /// <summary>
        /// Register the Items property so it is known in the class.
        /// </summary>
        public static readonly PropertyData ItemsProperty = RegisterProperty("Items", typeof (ObservableCollection<IShoppingListItem>), null);
        #endregion

        #region IShoppingList Members
        /// <summary>
        /// Gets or sets the due date.
        /// </summary>
        public DateTime DueDate
        {
            get { return GetValue<DateTime>(DueDateProperty); }
            set { SetValue(DueDateProperty, value); }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        /// <summary>
        /// Gets or sets the shop.
        /// </summary>
        public IShop Shop
        {
            get { return GetValue<IShop>(ShopProperty); }
            set { SetValue(ShopProperty, value); }
        }

        /// <summary>
        /// Gets the list of shopping items.
        /// </summary>
        public ObservableCollection<IShoppingListItem> Items
        {
            get { return GetValue<ObservableCollection<IShoppingListItem>>(ItemsProperty); }
            private set { SetValue(ItemsProperty, value); }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Validates the field values of this object. Override this method to enable
        /// validation of field values.
        /// </summary>
        /// <param name="validationResults">The validation results, add additional results to this list.</param>
        protected override void ValidateFields(List<IFieldValidationResult> validationResults)
        {
            if (Shop == null)
            {
                validationResults.Add(FieldValidationResult.CreateError(ShopProperty, "Shop is required"));
            }
        }
        #endregion
    }
}