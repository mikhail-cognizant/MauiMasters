﻿namespace MauiMasters.Services;

public interface IGroceryService
{
    Task<IEnumerable<GroceryItem>> GetGroceryItems();
}