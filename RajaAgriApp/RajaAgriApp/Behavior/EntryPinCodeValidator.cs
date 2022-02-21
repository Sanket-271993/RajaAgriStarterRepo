using Xamarin.Forms;

namespace RajaAgriApp.Behavior
{
    public class EntryPinCodeValidator : Behavior<Entry>
    {
        public int MaxLength { get; set; }


        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += OnEntryTextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= OnEntryTextChanged;
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;

            // if Entry text is longer than valid length  
            if (entry.Text.Length > this.MaxLength)
            {
                string entryText = entry.Text;

                entryText = entryText.Remove(entryText.Length - 1); // remove last char  

                entry.Text = entryText;
            }
            if (entry.Text.Equals("00000"))
            {
                ((Entry)sender).TextColor = Color.Red;
            }
            else
            {
                ((Entry)sender).TextColor = Color.Black;
            }

            if (MaxLength > 0)
                if (entry.Text.Length < this.MaxLength)
                {
                    ((Entry)sender).TextColor = Color.Red;
                }
                else
                    ((Entry)sender).TextColor = Color.Black;

            
        }
    }
}
