# ConsoleMenu

A menu system for Console Apps

```
  Main Menu
  ---------

> Sub Menu 1
  Sub Menu 2

  Exit
```

By default up/down arrow keys will move the indicator and enter will trigger the callback.

## Basic Usage
```c#
// Program.cs
class Program
{
    static void Main(string[] args)
    {
        var m = new MainMenu();
        m.Show();
    }
}
```
```c#
// MainMenu.cs
public class MainMenu
{
    Menu _mnu = new Menu();
    bool _exit = false;

    public MainMenu()
    {
        var exit = new MenuOption("Exit", () => Environment.Exit(0))
            .SetExits()
            .AddSpacer();

        _mnu = new Menu()
            .AddTitle("Main Menu")
            .AddOption(new MenuOption("Sub Menu 1", () => ShowSubMenuOne()))
            .AddOption(new MenuOption("Sub Menu 2", () => ShowSubMenuTwo()))
            .AddOption(exit);
    }

    public void Show()
    {
        do
        {
            _exit = _mnu.OutputMenu();
        }
        while (!_exit);
    }

    private void ShowSubMenuOne()
    {
        var m = new SubOne();
        m.Show();
    }

    private void ShowSubMenuTwo()
    {
        var m = new SubTwo();
        m.Show();
    }
}
```
## Additional Options

### Title

Outputs a title with underline (optional) first.

```c#
_mnu = new Menu()
    .AddTitle("Main Menu")
```

### Header

Ouptuts some text after the title, before the menu is printed.

```c#
_mnu = new Menu()
    .AddHeader("Use arrow keys to select to move indicator, enter to select...")
```

### Footer

Ouptuts some text after the menu is printed.

```c#
_mnu = new Menu()
    .AddFooter("Use arrow keys to select to move indicator, enter to select...")
```

### Key Press Callback

Adds the ability to add additional key press callbacks to the menu

```c#
_mnu = new Menu()
    // Pressing space will output "Space Pressed..." to the output window in Visual Studio
    .AddCallback(ConsoleKey.Spacebar, () => Debug.WriteLine("Space Pressed..."))
```

## Menu Option
### Basic Usage
```c#
var opt = new MenuOption("Menu Option Name", () => CallBack())
```
### Additional Options
#### Exits

Will exit the menu when selected return control back to the caller.

```c#
var opt.SetExits();
```
#### Spacer

Adds a spacer to the menu option, spacer is rendered before the menu is printed.

```c#
var opt.AddSpacer();
```

#### Trigger Type

Set the type of trigger to be used, Enter Key Pressed or On Select

```c#
var opt.SetTriggerType(MenuOptionTriggerType.OnSelect);
```
