   M S B A M L   `   `   `  ����A  =Buveur, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:BuveurBuveur  5   	       Buveur.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Buveur     5   	   -   5          � Title$  	Alcootest��5   	   $	��600��6   $	��530��6(   $��./#Roboto Lt)�64    � WindowStyle$
 None=�6N    � 	Resources 5	       �� MergedDictionaries �� Source�� 5
   
    5      �� 5      $e _pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml?�6%   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?�6%   �� 5      $y spack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.LightBlue.xaml?�6%   �� 5      $s mpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml?�6%   %    5      .��5      � -   5        $��Grid1��5      .+�5   
   �� ���	#FF0097FF$��1q�6)   $��10,227,26,133q�6=   �� 5   
   ���	#FF0097FF$��1q�6)   $��
10,60,26,0q�6=   $	��156��6Q   $	��Top=�6^   �� 5   
   -   5         ��Name$ 
labelPoids��5      $��Poids :��6$   $��	29,88,0,0q�66   $	��Top=�6I   $
��Left=�6a   $��49��6|   $��./#Roboto Lt)�6�   �� 5   
   -   5         ��Name$ textBoxPoids��5      $��26��6(   $��	78,90,0,0q�64    �� TextWrapping$
 Wrap=�6G   $�� ��6[   $	��Top=�6c   $
��Left=�6{   $	��120��6�    �� 	MaxLength$ 3��6�   	 �� MaxLines$	 1��6�   
 J� RenderTransformOrigin$
 	0.5,0.135&�6�   $��./#Roboto Lt)�6�   �� 5   
   -   5         ��Name$
 Sexe��5      $
��Sexe��6!   $��
288,79,0,0q�6/   $	��Top=�6C   $
 -1.31,-2.304&�6[   $��57��6�   $
��Left=�6�   $��87��6�   $��./#Roboto Lt)�6�   .��5      �� -   5         ��Name$ stackpanel1��5      .+�5      	� -   5         	�Name$ homme��5       d� 	IsChecked$ FalseY�6-   $��Homme��6?   $��./#Roboto Lt)�6O   	� 5      -   5        $ femme��5      $ FalseY�6-   $��Femme��6?   $��./#Roboto Lt)�6O   5      5      �� 5   
   -	   5         ��Name$ checkBoxJeuneConducteur��5      $��Jeune conducteur��64   $
��Left=�6O   $��
29,148,0,0q�6j   $	��Top=�6~   $
 0.636,-1.278&�6�   $ FalseY�6�   $��./#Roboto Lt)�6�   �� 5   
   -
   5         ��Name$ buttonAjouterPersonne��5      $��Ajouter Personne��60   $��183,161,171,0q�6K   $	��Top=�6b   $��29��6�   $	��168��6�   $��Center=�6�   $��./#Roboto Lt)�6�   $
��Bold"�6�   �� 5!   
   -   5        $ labelPersonneCree��5!      $�� ��6+   $��
56,83,56,0q�66   $	��Top=�6J   $��56��6b   $��16(�6n   $��Center=�6|   $y�Hidden=�6�   $��./#Roboto Lt)�6�   �� 5"   
   -   5        $ labelConduite��5"      $�� ��6'   $��10,117,26,0q�62   $	��Top=�6G   $��49��6_   $��16(�6k   $��Center=�6y   $
��auto��6�   $y�Hidden=�6�   $��./#Roboto Lt)�6�   �� 5#   
   -   5        $ labelAffichageTaux��5#      $�� ��6,   $��56,161,111,0q�67   $��Center=�6M   $	��Top=�6j   $��56��6�   $y�Hidden=�6�   $��./#Roboto Lt)�6�   �� 5$   
   -   5         ��Name$ listBoxAlcool��5$      $��262,239,50,165q�6)   $
 -0.303,0.203&�6A   $��./#Roboto Lt)�6�   �� 5%   
   -   5        $ labelNomBoisson��5%      $��Nom boisson :��6)   $
��Left=�6A   $��
29,250,0,0q�6\   $��./#Roboto Lt)�6p   $��24��6�   $	��Top=�6�   �� 5&   
   -   5        $ textBoxNomAlcool��5&      $
��Left=�6,   $��129,248,0,0q�6G   $
 Wrap=�6\   $�� ��6p   $	��120��6x    �� 
IsReadOnly .  $��./#Roboto Lt)�6�   $��26��6�   $	��Top=�6�   �� 5'   
   -   5        $ label1��5'      $��Quantité :��6    $
��Left=�65   $��
29,308,0,0q�6P   $��./#Roboto Lt)�6d   $��24��6~   $	��Top=�6�   �� 5(   
   -   5        $ textBoxquantite��5(      $
��Left=�6+   $��129,299,0,0q�6F   $
 Wrap=�6[   $�� ��6o   $	��120��6w   $	 1��6�   $��33��6�   $	��Top=�6�   $��./#Roboto Lt)�6�   �� 5)   
   -   5        $ 	labelTaux��5)      $��Taux :��6#   $
��Left=�64   $��
29,365,0,0q�6O   $��24��6c   $	��Top=�6o   $��./#Roboto Lt)�6�   �� 5*   
   -   5        $ textBoxtaux��5*      $
��Left=�6'   $��129,356,0,0q�6B   $
 Wrap=�6W   $�� ��6k   $	��120��6s   $ 5��6   $	 1��6�   $��33��6�   $	��Top=�6�   $��./#Roboto Lt)�6�   �� 5+   
   -   5        $ buttonAjoutListe��5+      $��Ajouter a la liste��6+   $��168,0,167,91q�6H   $
 -0.093,0.45&�6^   $��32��6�   $��Bottom=�6�   $��Center=�6�   $	��187��6�   $��./#Roboto Lt)�6�   $
��Bold"�6  �� 5,   
   -   5        $ buttonCalculTaux��5,      $��Calculer taux��6+   $��168,0,167,54q�6C   $��32��6n   $��Bottom=�6z   $��Center=�6�   $	��187��6�   $��./#Roboto Lt)�6�   $
��Bold"�6�   �� 5-   
   -   5        $ buttonReset��5-      $��Réinitialiser��6&   $��168,0,167,17q�6>   $
 0.383,0.044&�6T   $��32��6�   $��Bottom=�6�   $	��187��6�   $��Center=�6�   $��./#Roboto Lt)�6�   $
��Bold"�6�   �� 5.   
   -   5        $ 
buttonInfo��5.      $��i��6%   $��Right=�61   $	��Top=�6M   $��37��6e   $��24��6p   $��./#Roboto Lt)�6|   $��	0,0,150,0q�6�   $��Normal$�6�   $��Normal"�6�   �� 5/   
   -   5        $ buttonRediure��5/      $��_��6(   $��Right=�64   $	��Top=�6P   $��48��6h   $��24��6s   $��./#Roboto Lt)�6   $��	0,0,100,0q�6�   $��Normal$�6�   $��Normal"�6�   �� 50   
   -   5        $ buttonAgrandir��50      $	��□��6)   $��Right=�65   $	��Top=�6Q   $��48��6i   $��24��6t   $��./#Roboto Lt)�6�   $��0,0,50,0q�6�   $��Normal$�6�   $��Normal"�6�   �� 52   
   -   5        $ buttonFermer��52      $��X��6'   $��Right=�63   $	��Top=�6O   $��48��6g   $��24��6r   $��./#Roboto Lt)�6~   $��Normal$�6�   $��Normal"�6�   53      54      