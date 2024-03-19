const reactDescriptions = ['Fundamental', 'Crucial', 'Core'];

function genRandomInt(max) {
    return Math.floor(Math.random() * (max + 1));
}

export function RandomDescription() {
    const description = reactDescriptions[genRandomInt(2)];
    //console.log("yo")

    return (
        // <header>
        //     <img src="src/assets/react-core-concepts.png" alt="Stylized atom" />
        //     <h1>React Essentials</h1>
        //     <p>
        //         {description} React concepts you will need for almost any app you are
        //         going to build!
        //     </p>
        // </header>

        <div>
          {description}
        </div>
    );
}