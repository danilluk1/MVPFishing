namespace Fishing.BL.View {

    public interface IView {

        void Open();

        void Down();

        Fishing.Presenter.BasePresenter Presenter { set; }
    }
}