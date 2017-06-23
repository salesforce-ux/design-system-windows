# Lightning Design System tokens, icons and fonts for Windows

MS XAML configuration files for [Salesforce Lightning Design System](https://www.lightningdesignsystem.com/) [Tokens](https://www.lightningdesignsystem.com/design-tokens/).

Current release: Spring ’17

## Simple Install

Available on Nuget: https://www.nuget.org/packages/SalesforceDesignSystem/

[![NuGet Badge](https://buildstats.info/nuget/nunit)](https://buildstats.info/nuget/SalesforceDesignSystem/)

Install-Package SalesforceDesignSystem

Add SLDS library to App.xaml:

```
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <designSystem:Tokens />
            <designSystem:Brushes />
            <designSystem:Fonts />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## Sample Application 

See [Demo App](https://github.com/salesforce-ux/design-system-windows/tree/master/sample/SampleApp)

### Examples

#### Colors

```
<Grid Background="{StaticResource SLDS_COLOR_BACKGROUND_BRUSH}"/>
```


#### Fonts and text sizes

```
 <Style x:Key="DefaultTextStyle" TargetType="TextBlock">
    <Setter Property="FontFamily"
            Value="{StaticResource SalesforceDefaultFontFamily}" />
    <Setter Property="Foreground"
            Value="{ThemeResource SLDS_COLOR_TEXT_DEFAULT_BRUSH}" />
 </Style>

```


#### Icons

##### Action Icons

```
var tb = new TextBlock()
{
    FontFamily = (FontFamily) Application.Current.Resources["SalesforceDesignSystemIcons"],
    Text = IconConstants.IconAction.ActionAddContact
};

```


##### Custom Icons

```
var tb = new TextBlock()
{
    FontFamily = (FontFamily) Application.Current.Resources["SalesforceDesignSystemIcons"],
    Text =  IconConstants.IconCustom.Custom1
};

```


##### Standard Icons

```
var tb = new TextBlock()
{
    FontFamily = (FontFamily) Application.Current.Resources["SalesforceDesignSystemIcons"],
    Text = IconConstants.IconStandard.StandardAccount
};

```


##### Utility Icons


```
var tb = new TextBlock()
{
    FontFamily = (FontFamily) Application.Current.Resources["SalesforceDesignSystemIcons"],
    Text = IconConstants.IconUtility.UtilitySort
};

```

## Library Build (not required)

```
$ npm install
$ gulp
```

## Licenses

* Source code is licensed under [BSD 3-Clause](https://git.io/sfdc-license)
* All icons and images are licensed under [Creative Commons Attribution-NoDerivatives 4.0](https://github.com/salesforce-ux/licenses/blob/master/LICENSE-icons-images.txt)
* The Salesforce Sans font is licensed under our [font license](https://github.com/salesforce-ux/licenses/blob/master/LICENSE-font.txt)
