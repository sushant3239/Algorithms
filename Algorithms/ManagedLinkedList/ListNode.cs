namespace ManagedLinkedList
{
    public class ListNode<T>
    {
        public ListNode<T> PreviousNode { get; set; }
        public ListNode<T> NextNode { get; set; }
        public T Value { get; set; }
    }
}
