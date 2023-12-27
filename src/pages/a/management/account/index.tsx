import type { NextPage } from 'next';
import styles from './index.module.css';


const SignIn:NextPage = () => {
  	return (
        <div className={styles.myBody}>
    		<div className={styles.signIn}>
      			<img className={styles.frameIcon1} alt="" src="Frame.png" />
      			<img className={styles.frameIcon2} alt="" src="Frame.png" />
      			<div className={styles.rectangleParent}>
        				<div className={styles.groupChild} />
        				<b className={styles.signInto}>Sign Into</b>
        				<b className={styles.yourAccount}>Your Account</b>
        				<div className={styles.groupParent}>
          					<div className={styles.rectangleGroup}>
            						<div className={styles.groupItem} />
            						<b className={styles.signIn1}>Sign in</b>
          					</div>
          					<div className={styles.groupDiv}>
            						<div className={styles.companyIdParent}>
              							<div className={styles.companyId}>Company ID</div>
              							<div className={styles.groupInner} />
              							<img className={styles.briefcaseIcon1} alt="" src="briefcase.png" />
            						</div>
            						<div className={styles.passwordParent}>
              							<div className={styles.companyId}>Password</div>
              							<div className={styles.rectangleDiv} />
              							<img className={styles.lockIcon1} alt="" src="lock.png" />
            						</div>
            						<div className={styles.rememberMeParent}>
              							<div className={styles.rememberMe}>Remember Me</div>
              							<div className={styles.groupChild1} />
            						</div>
          					</div>
        				</div>
      			</div>
      			<div className={styles.yourLogoParent}>
        				<div className={styles.yourLogo}>Your Logo</div>
        				<img className={styles.frameIcon3} alt="" src="Frame.png" />
      			</div>
      			<div className={styles.signInChild} />
                  </div>
    		</div>);
};

export default SignIn;
