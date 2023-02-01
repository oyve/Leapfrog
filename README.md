# Leapfrog

A learning project in WPF technologies and recent frameworks, such as:

- WPF / C# 6.0
- MVP (Presenters, Application composition, separation of concern)
- MVVM (Commands, ViewModels, DataBinding)
- Dependency Injection and Messaging (loosely-coupled)

Frameworks
- CommunityToolkit.MVVM
- Microsoft.Extension.DependencyInjection

(with little emphasize on styling and tests)

![GitHub Logo](/leapfrog.png)

## Application buildup

*MainPresenter* is responsible for the overall orchestration of the application layout, whereas *NavigationPresenter* and *BrowserPresenter* is responsible for the *Navigation View* and the *Browser View*.

- This pattern is also referred to as *MVPVM* (MVP+MVVM).
- A presenter knows only 1 view, but could know other presenters. A *Presenter* is responsible for orchestrating its associated *View*.
- Views communicate their actions via events through either databindings to a *ViewModel* (such as a *Command*), or also *EventHandlers* to *Presenters* where necessary, such as *+=ViewLoaded*).
- No view logic. A view does not have any references, or know anything about the world. *View* code behind is minimized to a bare minimum.
- Microsoft.Extension.DependencyInjection is used to resolve runtime dependencies.
- *CommunityToolkit.MVVM.WeakReferenceMessenger* is used to raise and listen to cross-View events, such as loosely-coupled communication between the Navigation View and the Browser View. This is especially seen in the "Back" and "Forward" buttons, who will enable/disable depending on the possibility to navigate backward or forward.
- Example of F5 and F6 application-wide Keyboard events (refresh and set to focus to navigation bar)

## Todo
This learning projects does not cover the use of *Models* through *Services/Repository*. However, on a general principle, the *Presenter* should be the one who fetch data sources. *Models* are fed to the *ViewModel* (perhaps trimmed or manipulated) by the *Presenter*, who is responsible for setting the *DataContext* (read: the *ViewModel*) to the *View*. This help reduce the *ViewModels* responsibility to only concern data/events, and not also dependencies and other logic.
PS: The *View* should not have any knowledge about *Models* either to resepect the *MVP pattern* (unlike the original *MVC pattern*)

## Disclaimer
There are two sub-patterns to the MVP pattern, as described by Martin Fowler. There is also different opionions whether a View should hard reference a Presenter or only through Events. I have chosen the latter approach in this example.
