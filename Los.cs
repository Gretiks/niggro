namespace ConsoleApp1 {
    public class Los {
        List<int> list;

        public Los() {
            list = new List<int>();

            for (int i = 0; i < 6; i++) {
                list.Add(i);
            }
            
        }

        public List<int> getList() {
            return list;
        }
        public Los(List<int> list) {
            this.list = list;
        }

        public void toString() {
            foreach (int x in list) {
                Console.Write(" ");
                Console.Write(x + ",");
                
            }
                
        }
        
    }
    
}
