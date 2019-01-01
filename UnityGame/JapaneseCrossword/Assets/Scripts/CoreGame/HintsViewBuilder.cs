using IHintsGridBuider = JapaneseCrossword.Core.IHintsGridBuider;

namespace Assets.Scripts.CoreGame
{
    public class VerticalHintsBuilder : IHintsGridBuider {

        // Use this for initialization
        void Start () {
		
        }
	
        // Update is called once per frame
        void Update () {
		
        }

        public void Build(int[,] gridData)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool IsVertical => true;
    }
}
