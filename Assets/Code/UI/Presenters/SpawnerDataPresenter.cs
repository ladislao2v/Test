using Code.Services.Data;
using Code.UI.View;

namespace Code.UI.Presenters
{
    public class SpawnerDataPresenter
    {
        private readonly SpawnerData _model;
        private readonly SpawnerDataView _view;

        public SpawnerDataPresenter(SpawnerData model, SpawnerDataView view)
        {
            _model = model;
            _view = view;
        }

        public void Enable()
        {
            _view.IntervalChanged += _model.OnIntervalChanged;
            _view.SpeedChanged += _model.OnSpeedChanged;
            _view.DistanceChanged += _model.OnDistanceChanged;
        }

        public void Disable()
        {
            _view.IntervalChanged -= _model.OnIntervalChanged;
            _view.SpeedChanged -= _model.OnSpeedChanged;
            _view.DistanceChanged -= _model.OnDistanceChanged;
        }
    }
}