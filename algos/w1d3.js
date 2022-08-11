/**
 * A class to represents a single item of a SinglyLinkedList that can be
 * linked to other Node instances to form a list of linked nodes.
 */
class ListNode {
    /**
     * Constructs a new Node instance. Executed when the 'new' keyword is used.
     * @param {any} data The data to be added into this new instance of a Node.
     *    The data can be anything, just like an array can contain strings,
     *    numbers, objects, etc.
     * @returns {ListNode} A new Node instance is returned automatically without
     *    having to be explicitly written (implicit return).
     */
    constructor(data) {
        this.data = data;
    /**
       * This property is used to link this node to whichever node is next
       * in the list. By default, this new node is not linked to any other
       * nodes, so the setting / updating of this property will happen sometime
       * after this node is created.
       *
       * @type {ListNode|null}
       */
        this.next = null;
    }
}

/**
   * This class keeps track of the start (head) of the list and to store all the
   * functionality (methods) that each list should have.
   */
class SinglyLinkedList {
    /**
     * Constructs a new instance of an empty linked list that inherits all the
     * methods.
     * @returns {SinglyLinkedList} The new list that is instantiated is implicitly
     *    returned without having to explicitly write "return".
     */
    constructor() {
      /** @type {ListNode|null} */
        this.head = null;
    }
    /**
     * Concatenates the nodes of a given list onto the back of this list.
     * - Time: O(?).
     * - Space: O(?).
     * @param {SinglyLinkedList} addList An instance of a different list whose
     *    whose nodes will be added to the back of this list.
     * @returns {SinglyLinkedList} This list with the added nodes.
     */
    concat(addList) {
        if (addList == null) {
            return this; 
        }
        if (this.isEmpty()){
            return addList; 
        }
        let runner = this.head;

        while (runner.next !== null) {
        runner = runner.next;
        }

        runner.next = addList.head;
        return this;

    }
    /**
      * Finds the node with the smallest data and moves that node to the front of
      * this list.
      * - Time: O(?).
      * - Space: O(?).
      * @returns {SinglyLinkedList} This list.
      */
    moveMinToFront() {
        if (this.isEmpty()){
            return null;
        }
        let runner = this.head;
        let min = this.head;
        let skip = this.head;  
        while (runner.next){
            if(runner.data < min.data){
                skip = runner.next; 
                min = runner.data; 
            }
            else{
                runner = runner.next; 
            }
        }
        skip 
        min = this.head; 
        runner.next = min; 
        while(runner.next){
            runner = runner.next 
        }
        runner.next = skip; 

    }

     // EXTRA
    /**
      * Splits this list into two lists where the 2nd list starts with the node
      * that has the given value.
      * splitOnVal(5) for the list (1=>3=>5=>2=>4) will change list to (1=>3)
      * and the return value will be a new list containing (5=>2=>4)
      * - Time: O(?).
      * - Space: O(?).
      * @param {any} val The value in the node that the list should be split on.
      * @returns {SinglyLinkedList} The split list containing the nodes that are
      *    no longer in this list.
      */
    splitOnVal(val) {}
    /**
     * Retrieves the data of the second to last node in this list.
     * - Time: O(?).
     * - Space: O(?).
     * @returns {any} The data of the second to last node or null if there is no
     *    second to last node.
     */
    secondToLast() {
        let temp = this.head; 

        while (temp.next.next !== null){
            temp = temp.next;
        }
        return temp.data; 
    }

    /**
      * Removes the node that has the matching given val as it's data.
      * - Time: O(?).
      * - Space: O(?).
      * @param {any} val The value to compare to the node's data to find the
      *    node to be removed.
      * @returns {boolean} Indicates if a node was removed or not.
      */
    removeVal(val) {
        let current = this.head; 
        while(current !== null){
            if(current.next.data == val){
                current.next = current.next.next; 
                return true;
            }
            else{
                return false; 
            }
            current = current.next;
        }
        
    }

     // EXTRA
    /**
      * Inserts a new node before a node that has the given value as its data.
      * - Time: O(?).
      * - Space: O(?).
      * @param {any} newVal The value to use for the new node that is being added.
      * @param {any} targetVal The value to use to find the node that the newVal
      *    should be inserted in front of.
      * @returns {boolean} To indicate whether the node was pre-pended or not.
      */
    prepend(newVal, targetVal) {}


    /**
     * Removes the last node of this list.
     * - Time: O(?).
     * - Space: O(?).
     * @returns {any} The data from the node that was removed.
     */
    removeBack2(){
        if (this.isEmpty()){
            return null;
        }
        if(this.head.next === null){
            return this.removeHead();
        }
        let currentNode = this.head;
        while(currentNode.next.next){
            currentNode = currentNode.next;
        }
        const removedNode = currentNode.next;
        currentNode.next = null;
        return removedNode;
    }

    contains(val) {
        let current = this.head;

        while(current !== null){
            if(current.data == val){
                return true;
            }
            current = current.next;
        }
        return false;
    }

    containsRecursive(val, current = this.head) {
        //check to see if its empty 
        if(current === null){
            return false;
        }
        if(current.data === val){
            return true;
        }
        return this.containsRecursive(val, current.next)
    }

    // EXTRA
    /**
     * Recursively finds the maximum integer data of the nodes in this list.
     * - Time: O(?).
     * - Space: O(?).
     * @param {ListNode} runner The start or current node during traversal, or null
     *    when the end of the list is reached.
     * @param {ListNode} maxNode Keeps track of the node that contains the current
     *    max integer as it's data.
     * @returns {?number} The max int or null if none.
     */
    recursiveMax(runner = this.head, maxNode = this.head) {
        if (this.head === null) {
            return null;
        }
    
        if (runner === null) {
            return maxNode.data;
        }
    
        if (runner.data > maxNode.data) {
            maxNode = runner;
        }
    
        return this.recursiveMax(runner.next, maxNode);
    }
    

    /**
     * Creates a new node with the given data and inserts that node at the front
     * of the list.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @param {any} data The data for the new node.
     * @returns {SinglyLinkedList} This list.
     */
    insertAtFront(data){
        const newHead = new ListNode(data);
        newHead.next = this.head;
        this.head = newHead;
        return this;
    }

    /**
     * Removes the first node of this list.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {any} The data from the removed node.
     */
    removeHead() {
        if (this.isEmpty()) {
        return null;
    }

        const oldHead = this.head;
        this.head = oldHead.next;
        return oldHead.data;
    }

    /**
     * Calculates the average of this list.
     * - Time: O(n) linear, n = length of list.
     * - Space: O(1) constant.
     * @returns {number|NaN} The average of the node's data.
     */
    average() {
        let runner = this.head;
        let sum = 0;
        let cnt = 0;

    while (runner) {
        cnt++;
        sum += runner.data;
        runner = runner.next;
    }
    }
    
    /**
     * Determines if this list is empty.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {boolean}
    */
    isEmpty() {
        return this.head === null;
    }

    /**
     * Creates a new node with the given data and inserts it at the back of
     * this list.
     * - Time: O(n) linear, n = length of list.
     * - Space: O(1) constant.
     * @param {any} data The data to be added to the new node.
     * @returns {SinglyLinkedList} This list.
    */
    insertAtBack(data) {
        const newBack = new ListNode(data);

    if (this.isEmpty()) {
        this.head = newBack;
        return this;
    }

    let runner = this.head;

    while (runner.next !== null) {
        runner = runner.next;
    }

    runner.next = newBack;
    return this;
    }

    /**
     * Creates a new node with the given data and inserts it at the back of
     * this list.
     * - Time: O(n) linear, n = length of list.
     * - Space: O(n) linear due to the call stack.
     * @param {any} data The data to be added to the new node.
     * @param {?ListNode} runner The current node during the traversal of this list
     *    or null when the end of the list has been reached.
     * @returns {SinglyLinkedList} This list.
    */
    insertAtBackRecursive(data, runner = this.head) {
        if (this.isEmpty()) {
        this.head = new ListNode(data);
        return this;
    }

        if (runner.next === null) {
        runner.next = new ListNode(data);
        return this;
    }
        return this.insertAtBackRecursive(data, runner.next);
    }  

    /**
     * Calls insertAtBack on each item of the given array.
     * - Time: O(n * m) n = list length, m = arr.length.
     * - Space: O(1) constant.
     * @param {Array<any>} vals The data for each new node.
     * @returns {SinglyLinkedList} This list.
     */
    insertAtBackMany(vals) {
        for (const item of vals) {
        this.insertAtBack(item);
    }
        return this;
    }

    /**
     * Converts this list into an array containing the data of each node.
     * - Time: O(n) linear.
     * - Space: O(n).
     * @returns {Array<any>} An array of each node's data.
     */
    toArr() {
        const arr = [];
        let runner = this.head;

        while (runner) {
        arr.push(runner.data);
        runner = runner.next;
    }
    return arr;
    }
}

/******************************************************************* 
Multiple test lists already constructed to test your methods on.
Below commented code depends on insertAtBack method to be completed,
after completing it, uncomment the code.
*/
const emptyList = new SinglyLinkedList();

  // const singleNodeList = new SinglyLinkedList().insertAtBackMany([1]);
  // const biNodeList = new SinglyLinkedList().insertAtBackMany([1, 2]);
// const firstThreeList = new SinglyLinkedList().insertAtBackMany([1, 2, 3]);
const secondThreeList = new SinglyLinkedList().insertAtBackMany([4, 5, 6]);
const unorderedList = new SinglyLinkedList().insertAtBackMany([
    -5, -10, 4, -3, 6, 1, -7, -2, 69]);
    // console.log(unorderedList.());
const minList = unorderedList.moveMinToFront();
console.log(minList.toArr());

//     console.log(unorderedList.secondToLast());
//     console.log(unorderedList.removeVal(-9));

const concatList = secondThreeList.concat(unorderedList);
console.log(concatList.toArr());

  /* node 4 connects to node 1, back to head */
  // const perfectLoopList = new SinglyLinkedList().insertAtBackMany([1, 2, 3, 4]);
  // perfectLoopList.head.next.next.next = perfectLoopList.head;

  /* node 4 connects to node 2 */
  // const loopList = new SinglyLinkedList().insertAtBackMany([1, 2, 3, 4]);
  // loopList.head.next.next.next = loopList.head.next;

  // const sortedDupeList = new SinglyLinkedList().insertAtBackMany([
  //   1, 1, 1, 2, 3, 3, 4, 5, 5,
  // ]);

  // Print your list like so: 
  // console.log(firstThreeList.toArr());
  // console.log(biNodeList.toArr());
  // console.log(singleNodeList.toArr());