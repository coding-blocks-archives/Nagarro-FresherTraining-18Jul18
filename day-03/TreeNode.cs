namespace Tree
{
    public class TreeNode<T>{
        private T data;
        private TreeNode<T> left;
        private TreeNode<T> right;

        public TreeNode(T data){
            this.data = data;
            left = null;
            right = null;
        }

        public T GetData(){
            return data;
        }

        public void SetLeft(TreeNode<T> newLeft){
            this.left = newLeft;
        }

        public void SetRight(TreeNode<T> newRight){
            this.right = newRight;
        }

        public TreeNode<T> GetLeft(){
            return this.left;
        }

        public TreeNode<T> GetRight(){
            return this.right;
        }
    }
}