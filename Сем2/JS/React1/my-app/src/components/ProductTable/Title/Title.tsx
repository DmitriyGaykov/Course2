import ITitle from "./ITitle"
import Styles from './title.module.scss';

const Title = ({ text } : ITitle) => {
    return <span className={ Styles.title }>{ text }</span>
}

export default Title;