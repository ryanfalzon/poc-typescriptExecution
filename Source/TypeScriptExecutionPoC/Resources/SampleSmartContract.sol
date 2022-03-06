pragma solidity >=0.7.0 <0.9.0;

interface Space {
    function store(uint256 num) external;
    function retrieve() external view returns(uint256);
}

contract StorageA is Space {

    uint256 numberA;

    function store(uint256 num) public override {
        numberA = num;
    }

    function retrieve() public override view returns (uint256){
        return numberA;
    }
}

contract StorageB {

    uint256 public numberB;
    address someAddress;
    StorageA storageA;

    function storeAnother(uint256 num) public {
        numberB = num;
    }

    function retrieveAnother() public view returns (uint256){
        return numberB;
    }

    function add(uint256 number1, uint256 number2) private view onlyOwner returns (uint256) {
        return number1 + number2;
    }

    function areEqual(uint256 number1, uint256 number2) private returns (bool, uint256) {
        if(numberB == number1){
            numberB = number1;
        }

        else if(number2 == numberB){
            number2 = numberB;
        }

        else{
            number1 = numberB + number2;
            number1 = numberB - number2;
            number1 = numberB / number2;
            number1 = numberB * number2;
        }

        if(numberB == number2){
            number2 = numberB;
        }

        bool test = numberB == number2;
        uint256 anotherTest = numberB;

        return (test, numberB);
    }

    function storeInStorageA() private returns (bool) {
        storageA.store(numberB);
        return true;
    }

    modifier onlyOwner() {
        require(msg.sender == someAddress);
        _;
    }
}