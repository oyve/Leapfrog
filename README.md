# Leapfrog

A learning project in WPF technologies and recent frameworks, such as:

- WPF / C# 6.0
- MVP (Presenters, Layout composition)
- MVVM (Commands, ViewModels, DataBinding)
- Dependency Injection and Messaging (separation of concern, loosely-coupled)

Frameworks
- CommunityToolkit.MVVM
- Microsoft.Extension.DependencyInjection

(with little emphasize on styling and tests)

![GitHub Logo](/leapfrog.png)

## Application buildup

*MainPresenter* is responsible for the overall orchestration of the application layout, whereas *NavigationPresenter* and *BrowserPresenter* is responsible for the *Navigation View* and the *Browser View*.

- This pattern is also referred to as *MVPVM* (MVP+MVVM).
- A presenter knows only 1 view, but could know other presenters (either through loose-coupling or hard reference). A *Presenter* is responsible for orchestrating its associated *View*, and fetch data from typically a service to feed the ViewModel
- Views communicate actions via events through either databindings to a *ViewModel* (such as a *Command*), or also *EventHandlers* to *Presenters* where necessary, such as *+=ViewLoaded*).
- No view logic. A view does not have any references, or know anything about the world. *View* code behind is minimized to a bare minimum.
- Microsoft.Extension.DependencyInjection is used to resolve runtime dependencies.
- *CommunityToolkit.MVVM.WeakReferenceMessenger* is used to raise and listen to cross-View events, such as loosely-coupled communication between the Navigation View and the Browser View. This is especially seen in the "Back" and "Forward" buttons, who will enable/disable depending on the possibility to navigate backward or forward.
- Example of F5 and F6 application-wide Keyboard events (refresh and set to focus to navigation bar)

## Todo
This learning projects does not cover the use of *Domain Models* through *Services/Repository*. However, on a general principle, the *Presenter* should be the one who fetch data sources. Data, is fed to the *ViewModel* by the *Presenter*, who sets the *DataContext* (read: the *ViewModel*) for the *View*. This help reduce the *ViewModels* responsibility to only concern data/events, and not also dependencies and other logic.
Note: The *View* should not have any knowledge about *Domain Models* to fully respect the *MVP pattern* (unlike the original *MVC pattern*)

## Disclaimer
There are two sub-patterns to the MVP pattern, as described by Martin Fowler. There is also different opionions whether a View should reference the Presenter or only through subscribable Events. I have chosen the latter approach in this example as it keeps a cleaner separation.
