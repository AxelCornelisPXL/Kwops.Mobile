﻿namespace Kwops.Mobile.Services;

public interface INavigationService
{
    Task NavigateAsync(string routeName);
    Task NavigateRelativeAsync(string routeName);
}