namespace MyUserManagementApp
{
    public class NodeStructure<T>
    {
        //  constructor ensures that when the class is instantiated
        //  with a value then the value is assigned to the Node value
         public NodeStructure(T value)
        {
            this.Value = value;
        }
        public T Value { get; set; }                 //value
        public NodeStructure<T> Next { get; set; }   //pointer
    }
}