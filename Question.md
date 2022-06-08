<h2 align="center"> Question</h2>

#### 1. diff between IEnumerable vs. List
    IEnumerable types have a method to get the next item in the collection.
    It doesn't need the whole collection to be in memory and doesn't know how many items are in it, 
    foreach just keeps getting the next item until it runs out. 
    List implements IEnumerable, but represents the entire collection in memory.
    
    
#### 2. diff between IEnumerable vs. IQueryable
     IQueryable<T> extends the IEnumerable<T> interface
     IQueryable queries out-of-memory data stores, while IEnumerable queries in-memory data.
     Moreover, IQueryable is part of . NET's System.LINQ namespace, while IEnumerable is in System.
