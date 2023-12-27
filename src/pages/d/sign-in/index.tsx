import type { NextPage } from 'next';
import styles from './index.module.css';
import { useRouter } from 'next/router';


const Login:NextPage = () => {
	const router = useRouter()

	const handleSignupd = () => {
		router.push('./sign-up')
	}
  	return (
		<div className={styles.myBody}>
    		<div className={styles.login}>
      			<div className={styles.login1}>
        				<div className={styles.loginPage}>
          					<div className={styles.loginPageChild} />
          					<div className={styles.loginPageItem} />
          					<div className={styles.needWebdesignForContainer}>
            						<p className={styles.needWebdesign}>{`Need webdesign `}</p>
            						<p className={styles.needWebdesign}>{`for your business? `}</p>
            						<p className={styles.needWebdesign}>
              							<span className={styles.designSpacee}>Design Spacee</span>
              							<span>{` will help you.  `}</span>
            						</p>
          					</div>
          					<div className={styles.signIn}>Sign-in</div>
          					<div className={styles.loginContent}>
            						<div className={styles.dontHaveAnContainer}>
              							<span>{`Don’t have an account? `}</span>
              							<span className={styles.signupHere} onClick={handleSignupd}>Signup Here</span>
            						</div>
            						<div className={styles.inputName}>
              							<div className={styles.email}>Email</div>
              							<div className={styles.inputNameChild} />
            						</div>
            						<div className={styles.inputName1}>
              							<div className={styles.email}>Password</div>
              							<div className={styles.inputNameChild} />
            						</div>
            						<div className={styles.loginContentChild} />
            						<div className={styles.login2}>Login</div>
          					</div>
          					<div className={styles.figmacomdesignspacee}>figma.com/@designspacee</div>
          					<div className={styles.logo}>
            						<div className={styles.logoChild} />
            						<div className={styles.s}>S</div>
          					</div>
        				</div>
      			</div>
				  </div>
    		</div>);
};

export default Login;
