   M S B A M L   `   `   `  ����E  AOnBreak2.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:OnBreak2._0OnBreak2._0  5   	        OnBreak2._0.ListaContratos   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:OnBreak2._0     5   	     � Title$!  Onbreak: Lista de Contratos��5   	   $	��450��6-   $��1203.276��6:    � Icon$ assets/hat.png��6K   .��5	      � ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ Black��6    � Offset$ 0Q�6-   � 5      $ 	#FFFF925F��6   $ 1Q�61   5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DataContratos��5      $��Center=�6*   $��10,160,10,30q�6G   $��Center=�6]      AutoGenerateColumns .     
IsReadOnly . $	��229��6�   	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Numero Contrato��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6b   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *NumeroContrato1+6b     5      $
 Fecha Creacion��6%   $ * 6[    6=   �� *	Creacion1+6[     5      $
 Fecha Termino��6%   $ * 6Y    6<   �� *
Termino1+6Y     5      $
 Rut Cliente��6%   $ * 6Z    6:   �� *RutCliente1+6Z     5      $
 Nombre Contacto��6%   $ * 6a    6>   �� *NombreCliente1+6a     5      $
 Modalidad Servicio��6%   $ * 6`    6A   �� *
Modalidad1+6`     5      $
 Tipo Servicio��6%   $ * 6\    6<   �� *TipoEvento1+6\     5      $
 Fecha Inicio��6%   $ * 6`    6;   �� *FechaHoraInicio1+6`     5      $
 Fecha Termino��6%   $ * 6b    6<   �� *FechaHoraTermino1+6b     5      $
 
Asistentes��6%   $ * 6Y    69   �� *Asistentes1+6Y     5      $
 Personal Adicional��6%   $ * 6h    6A   �� *PersonalAdicional1+6h     5      $
 	Realizado��6%   $ * 6W    68   �� *
Realizado1+6W     5      $
 Valor Total��6%   $ * 6b    6:   �� *ValorTotalContrato1+6b     5      $
 Observaciones��6%   $ * 6_    6<   �� *Observaciones1+6_   5!      �� 5"   
   $��Lista Contrato��6   $��Center=�6)   $��301,10,307,0q�6F   $	��Top=�6\   
�������$��SimSun)�6�   $��24(�6�   $
��Bold"�6�   ��6t   Z� 6�   �� 5#   
   -   5         ��Name$ cmbTipoEvento��5#      $
��Left=�6*   $��
396,73,0,0q�6E   $	��Top=�6Y   $	��157��6q   6}   �� 5%   
   -   5        $ cmbModalidadEvento��5%      $
��Left=�6/   $��396,110,0,0q�6J   $	��Top=�6_   $	��157��6w   �� 5'   
   $��Numero Contrato:��6   $
��Left=�6+   $��	33,68,0,0q�6F   $	��Top=�6Y   $��27��6q   $��Center=�6}   
�������6�   �� 5(   
   $��Rut Cliente:��6   $
��Left=�6'   $��
33,105,0,0q�6B   $	��Top=�6V   $��27��6n   $��Center=�6z   
�������6�   �� 5)   
   $��Tipo Evento:��6   $
��Left=�6'   $��
279,68,0,0q�6B   $	��Top=�6V   $��27��6n   $��Center=�6z   
�������6�   �� 5*   
   $��Modalidad Evento:��6   $
��Left=�6,   $��279,105,0,0q�6G   $	��Top=�6\   $��27��6t   $��Center=�6�   
�������6�   �� 5+   
   -   5         ��Name$ btnFiltarContrato��5+      $��Filtrar��6,   $
��Left=�6>   $��
577,90,0,0q�6Y   $	��Top=�6m   $��75��6�   6�   �� 5,   
   -   5        $ btnLimpiarContrato��5,      $��Limpiar��6-   $
��Left=�6?   $��
674,90,0,0q�6Z   $	��Top=�6n   $��75��6�   6�   �� 5-   
   -   5         ��Name$ TextNumeroContrato��5-      $
��Left=�6.   $��22��6I   $��
144,73,0,0q�6U    �� TextWrapping$
 Wrap=�6i   $	��Top=�6}   $	��130��6�   �� 5.   
   -   5        $ TextRutCliente��5.      $
��Left=�6*   $��22��6E   $��144,110,0,0q�6Q   $
 Wrap=�6f   $	��Top=�6z   $	��130��6�   �� 5/   
   -   5        $ btnSeleccionar��5/      $��Seleccionar��6)   $��Center=�6?   $��0,0,0,5q�6\   $��Bottom=�6m   $��75��6�   6�   51      52      