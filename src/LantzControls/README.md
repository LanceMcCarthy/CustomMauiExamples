# Lantz Controls

This is project that has various custom controls and will evolve over time as I add more ([Jump to code](src/LantzControls/)).

-  `FloatingLabel`
-  `LabeledCheckBox`
-  `ColumnChooser` 

## FloatingLabel

```xaml
<primitives:FloatingLabel CornerRadius="10"
                            Text="Product Code"
                            FontSize="8"
                            TextColor="#0000fa"
                            WidthRequest="150"
                            VerticalOptions="Start"
                            HorizontalOptions="Start">
    <primitives:FloatingLabel.InnerContent>
        <telerik:RadEntry x:Name="MyRadEntry"
                            Placeholder="Product Code"
                            PlaceholderColor="#a8aba8"
                            FontSize="12"
                            HeightRequest="35"
                            CornerRadius="8"
                            BorderThickness="2"
                            BorderBrush="#a8aba8"
                            FocusedBorderThickness="0"
                            FocusedBorderBrush="Transparent"
                            HorizontalOptions="Fill" />
    </primitives:FloatingLabel.InnerContent>
</primitives:FloatingLabel>
```

#### Unfocused with RadEntry

![unfocused](https://user-images.githubusercontent.com/3520532/185198526-85ca9f1f-3f49-4db2-9fe4-0bd3d18bac3e.png)

#### Focused with RadEntry

![focused empty](https://user-images.githubusercontent.com/3520532/185198745-6760b46f-97aa-4f7f-98c3-99330f6325a5.png)

#### Focused with RadEntry and Text Content

![focused filled](https://user-images.githubusercontent.com/3520532/185198803-baaa19cc-ac66-4a21-9b5b-c85936d1e7e4.png)

## ColumnChooser

Can be attached to any RadDataGrid for user to show/hide any column.

![image](https://github.com/LanceMcCarthy/CustomMauiExamples/assets/3520532/082bda3f-6828-4669-b0f6-43fbb5e75579)

```xaml
<Grid ColumnDefinitions="*, Auto">
    <telerik:RadDataGrid x:Name="MyDataGrid"
                         AutoGenerateColumns="False">
        <telerik:RadDataGrid.Columns>
            <telerik:DataGridTextColumn PropertyName="Name" HeaderText="Name" />
            <telerik:DataGridNumericalColumn PropertyName="Age" HeaderText="Age" />
            <telerik:DataGridDateColumn PropertyName="DateOfBirth" HeaderText="DOB" CellContentFormat="{}{0:MM/dd/yyyy}" />
        </telerik:RadDataGrid.Columns>
    </telerik:RadDataGrid>

    <!-- Associate with a DataGrid -->
    <dataGrid:ColumnChooser x:Name="Chooser"
                            AssociatedDataGrid="{x:Reference MyDataGrid}"
                            Margin="20"
                            Grid.Column="1" />
</Grid>
```