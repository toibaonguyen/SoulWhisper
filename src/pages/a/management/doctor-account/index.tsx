import type { NextPage } from 'next';
import styles from './index.module.css';


const Desktop:NextPage = () => {
  	return (
        <div className={styles.myBody}>
    		<div className={styles.desktop}>
      			<div className={styles.bgcircle} />
      			<img className={styles.noiseTexture1} alt="" src={`Noise & Texture.png`} />
      			<div className={styles.formboxwrapper}>
        				<div className={styles.formbox}>
          					<img className={styles.formboxChild} alt="" src="Frame 5.png" />
          					<div className={styles.createAccount}>Doctor-Account</div>
          					<div className={styles.startYour301}>Start your 30 day free trial. Cancel any yime</div>
          					<div className={styles.signupbuttons}>
            						<div className={styles.signupwaybutton}>
              							<div className={styles.signUpWith2}>Sign up with Google</div>
              							<img className={styles.icongoogle} alt="" src="Icon/Google.png" />
            						</div>
            						<div className={styles.signupwaybutton}>
              							<div className={styles.signUpWith2}>Sign up with Facebook</div>
              							<img className={styles.icongoogle} alt="" src="Icon/Facebook.png" />
            						</div>
          					</div>
          					<div className={styles.ordivider}>
            						<div className={styles.border2} />
            						<div className={styles.or}>OR</div>
            						<div className={styles.border2} />
          					</div>
          					<div className={styles.button}>
            						<div className={styles.createAccount1}>Create Account</div>
          					</div>
          					<div className={styles.alreadyHaveAnContainer}>
            						<span>{`Already have an account? `}</span>
            						<span className={styles.logIn}>Log in</span>
          					</div>
          					<div className={styles.signupforms}>
            						<div className={styles.input}>
              							<div className={styles.or}>Email</div>
              							<div className={styles.input1}>
                								<div className={styles.johndoemailcom}>johndoe@mail.com</div>
              							</div>
            						</div>
            						<div className={styles.input}>
              							<div className={styles.or}>Password</div>
              							<div className={styles.input3}>
                								<div className={styles.eye}>eye</div>
                								<div className={styles.passwordtext}>
                  									<div className={styles.passwordtextChild} />
                  									<div className={styles.passwordtextChild} />
                  									<div className={styles.passwordtextChild} />
                  									<div className={styles.passwordtextChild} />
                  									<div className={styles.passwordtextChild} />
                  									<div className={styles.passwordtextChild} />
                  									<div className={styles.passwordtextChild} />
                  									<div className={styles.passwordtextChild} />
                								</div>
              							</div>
            						</div>
          					</div>
        				</div>
        				<img className={styles.logoIcon} alt="" src="Logo.png" />
      			</div>
      			<div className={styles.allRightsReserved1}>© 2023  All rights reserved.</div>
                  </div>
    		</div>);
};

export default Desktop;
