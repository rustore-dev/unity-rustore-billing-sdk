namespace RuStore.BillingExample.UI {

    public interface ICardView<T> {

        T GetData();
        void SetData(T value);
    }
}
