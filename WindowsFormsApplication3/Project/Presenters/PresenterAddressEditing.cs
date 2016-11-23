using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    // Сшивает воедино поведение IPageEditing
    public class PresenterAddressEditing
    {                                    
        public PresenterAddressEditing(
            IAddressTableProvider addressTableProvider, 
            IAddressEditingPanels addressEditingPanels,
            IAddressGenerator addressGenerator,
            Form_DiapasonAddressChoser form_DiapasonAddressChoser,
            Form_RandomAddress form_RandomAddress,
            IFileIO fileIO, 
            OpenFileDialog openFileDialog, 
            SaveFileDialog saveFileDialog)
        {
            // Вызов редактора диапазона ip
            addressEditingPanels.DiapasonChoiseRequired += () => {
                form_DiapasonAddressChoser.ShowDialog();
            };
            // Добавление диапазона
            form_DiapasonAddressChoser.AddingAdresses_Required += (DiapasonChoiserData obj) =>
            {
                BindingList<HostUri> temp = addressGenerator.CreateList_HostUri(obj);
                foreach (HostUri item in temp)
                    addressTableProvider.Addresses.Add(item);
            };
            // Вычитание диапазона
            form_DiapasonAddressChoser.RemovingAdresses_Required += (DiapasonChoiserData obj) =>
            {
                BindingList<HostUri> temp = addressGenerator.CreateList_HostUri(obj);
                
                foreach (HostUri item in temp)
                {
                    List<HostUri> delAddresses = addressTableProvider.Addresses.Where(x => x.Host == item.Host).ToList();
                    foreach (HostUri delAddress in delAddresses)
                        addressTableProvider.Addresses.Remove(delAddress);
                }
            };

            // Вызов редактора случайного ip
            addressEditingPanels.RandomIPChoiseRequired += () =>
            {
                form_RandomAddress.ShowDialog();
            };
            // Добавление ip
            form_RandomAddress.AddingAdresses_Required += (DiapasonChoiserData obj) =>
            {
                HostUri item = addressGenerator.CreateRandom_HostUri(obj);
                addressTableProvider.Addresses.Add(item);
            };


            // загрузка
            addressEditingPanels.LoadRequired += () =>
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    BindingList<HostUri> addresses = new BindingList<HostUri>(fileIO.ReadListAddress(openFileDialog.FileName));
                    addressTableProvider.Addresses.Clear();
                    foreach (HostUri item in addresses)
                        addressTableProvider.Addresses.Add(item);                    
                }
            };
            // сохранение
            addressEditingPanels.SaveRequired += () =>
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    HostUri[] adresses = addressTableProvider.Addresses.ToArray();
                    fileIO.WriteListAddress(saveFileDialog.FileName, adresses);
                }
            };
            
        }        
    }
}