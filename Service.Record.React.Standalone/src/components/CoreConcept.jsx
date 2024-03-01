export default function CoreConcept(props) {

  //console.log("yo");
  //console.log(props);
  //console.log(props.children)

    return (
      <li>      
        <h3>{props.title}</h3>
        <p>{props.description}</p>
        <img src={props.image} alt={props.title} />
      </li>
    );
  }