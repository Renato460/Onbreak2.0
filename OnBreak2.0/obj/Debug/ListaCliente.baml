   M S B A M L   `   `   `  ����E  AOnBreak2.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:OnBreak2._0OnBreak2._0  5   	       OnBreak2._0.ListaCliente   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:OnBreak2._0     5   	     � Title$   Onbreak: Lista de Clientes��5   	   $	��450��6,   $	��800��69   .��5	      � ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ Black��6    � Offset$ 0Q�6-   � 5      $ 	#FF1190CB��6   $ 1Q�61   5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DataClientes��5      $��Center=�6)   $��10,118,10,46q�6F   $��Center=�6\      AutoGenerateColumns .     
IsReadOnly . $	��255��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Rut Cliente��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6Z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *RutCliente1+6Z     5      $	 Nombre��6%   $
 * 6Y    65   �� *NombreContacto1+6Y     5      $	 	Direccion��6%   $
 * 6W    68   �� *
Direccion1+6W     5      $
	 Mail��6%   $
 * 6U    63   �� *MailContacto1+6U     5      $	 Telefono��6%   $
 * 6U    67   �� *	Telefono1+6U     5      $	 Razon Social��6%   $
 * 6\    6;   �� *RazonSocial1+6\     5      $	 Actividad Empresa��6%   $
 * 6f    6@   �� *ActividadEmpresa1+6f     5      $	 Tipo Empresa��6%   $
 * 6\    6;   �� *TipoEmpresa1+6\   5      �� 5   
   -   5         ��Name$ TituloListaCliente��5      $��Lista Clientes��6,   $��Center=�6E   $��0,10,0,0q�6b   $	��Top=�6t   
�������$��24(�6�   $
��Bold"�6�   $��SimSun)�6�   �� 5   
   -   5         ��Name$ btnSeleccionar��5      $��Seleccionar��6)   $��Center=�6?   $��330,0,327,10q�6\   $��Bottom=�6r   $	��103��6�   $��SimSun)�6�   $��16(�6�   $
��Bold"�6�   6�   �� 5   
   -   5         ��Name$ textRutCliente��5      $
��Left=�6*   $��23��6E   $��	44,77,0,0q�6Q    �� TextWrapping$
 Wrap=�6d   $	��Top=�6x   $	��120��6�   �� 5   
   $��Rut Cliente��6   $
��Left=�6&   $��	68,47,0,0q�6A   $	��Top=�6T   
�������$
��Bold"�6   �� 5    
   $��Tipo Empresa��6   $
��Left=�6'   $��
424,51,0,0q�6B   $	��Top=�6V   
�������$
��Bold"�6�   �� 5!   
   $��	Actividad��6   $
��Left=�6$   $��
247,50,0,0q�6?   $	��Top=�6S   
�������$
��Bold"�6~   �� 5"   
   -   5         ��Name$ combTipoEmpresa��5"      $
��Left=�6,   $��
389,77,0,0q�6G   $	��Top=�6[   $	��155��6s   �� 5#   
   -   5        $ combActividad��5#      $
��Left=�6*   $��
201,78,0,0q�6E   $	��Top=�6Y   $	��149��6q   �� 5$   
   -   5        $ 
btnFiltrar��5$      $��Filtrar��6%   $
��Left=�67   $��
588,77,0,0q�6R   $	��Top=�6f   $��75��6~   $��23��6�   $
��Bold"�6�   6�   �� 5%   
   -   5        $ 
btnLimpiar��5%      $��Limpiar��6%   $
��Left=�67   $��
690,77,0,0q�6R   $	��Top=�6f   $��75��6~   $��23��6�   $
��Bold"�6�   6�   5&      5'      