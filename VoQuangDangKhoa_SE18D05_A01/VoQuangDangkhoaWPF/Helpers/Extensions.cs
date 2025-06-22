using System.Windows;
using System.Windows.Media;

namespace VoQuangDangKhoaWPF.Helpers
{
    public static class Extensions
    {
        public static T TryFindParent<T>(this DependencyObject child) where T : DependencyObject
        {
            DependencyObject parent = VisualTreeHelper.GetParent(child);
            while (parent != null && !(parent is T))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            return parent as T;
        }
    }
}