export default function TabButton({ children, onSelect, isSelected }) {

    function handleClick() {
        //console.log("Good afternoon bitches. The " + children + " button was pressed.")
    }

    //console.log("TabButton component:");
    //console.log(children);

    return (
        <li>
            {/* <button onClick={handleClick}>{children}</button> */}
            {/* if isSelected is true, the class name is active.  if isSelected is not true
            class name is undefined */}
            <button className={isSelected ? 'active' : undefined} onClick={onSelect}>
                {children}
            </button>
        </li>
    );
}
