namespace Strukturen
{
    ref struct StackBuffer
    {
        private Span<int> _buffer;
        private int _position;

        public StackBuffer(Span<int> buffer)
        {
            _buffer = buffer;
            _position = 0;
        }

        public void Push(int wert)
        {
            if (_position >= _buffer.Length)
                throw new InvalidOperationException("Stack ist voll!");
            _buffer[_position++] = wert;
        }

        public int Pop()
        {
            if (_position == 0)
                throw new InvalidOperationException("Stack ist leer!");
            return _buffer[--_position];
        }
    }

}
