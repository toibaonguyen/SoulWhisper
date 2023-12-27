import type { NextPage } from 'next';
import styles from './index.module.css';
import { useRouter } from 'next/router';


const LoginPageDefaultStates:NextPage = () => {
	const router = useRouter()
	const handleSignind = () => {
		router.push('./sign-in')
	}
  	return (
        <div className={styles.myBody}>
    		<div className={styles.loginPageDefaultStates1}>
      			<div className={styles.loginPageDefaultStatesChild} />
      			<div className={styles.right}>
        				<div className={styles.getTheApp1}>
          					<div className={styles.buttns}>
            						<img className={styles.downloadBadgeGooglePlayB1} alt="" src="Download Badge / Google Play Badge.png" />
            						<img className={styles.downloadBadgeGooglePlayB1} alt="" src="Download Badge / App Store Badge.png" />
          					</div>
        				</div>
        				<div className={styles.dontHaveAnContainer}>
          					<span>{`Don’t have an account? `}</span>
          					<span className={styles.logIn}>Log In</span>
        				</div>
        				<div className={styles.form}>
          					<div className={styles.googleButton}>
            						<div className={styles.googleButtonChild} />
            						<div className={styles.signInWithGoogle1} onClick={handleSignind}>Sign-in with google</div>
            						<img className={styles.iconfinderGoogle129874511} alt="" src="iconfinder_Google_1298745 1.png" />
          					</div>
          					<div className={styles.loginButton}>
            						<div className={styles.loginButtonChild} />
            						<div className={styles.createAccount}>Create Account </div>
          					</div>
          					<div className={styles.forgotPassword}>Forgot password?</div>
            						<div className={styles.termsAndPrivacyPolicy1}>
              							<div className={styles.termsAndPrivacyPolicyChild} />
              							<div className={styles.iAgreeToContainer}>
                								<span>{`I agree to all the `}</span>
                								<span className={styles.logIn}>Terms</span>
                								<span>{` and `}</span>
                								<span className={styles.logIn}>{`Privacy policy `}</span>
              							</div>
            						</div>
            						<div className={styles.rememberMe}>
              							<div className={styles.termsAndPrivacyPolicyChild} />
              							<div className={styles.iAgreeToContainer}>Remember me</div>
            						</div>
            						<div className={styles.entryField}>
              							<div className={styles.entryField1}>
                								<div className={styles.iAgreeToContainer}>First name</div>
                								<div className={styles.entryFieldInner}>
                  									<div className={styles.groupChild} />
                								</div>
              							</div>
              							<div className={styles.entryField2}>
                								<div className={styles.iAgreeToContainer}>Email or phone number</div>
                								<div className={styles.entryFieldInner}>
                  									<div className={styles.groupChild} />
                								</div>
              							</div>
              							<div className={styles.entryField3}>
                								<div className={styles.iAgreeToContainer}>Password</div>
                								<div className={styles.entryFieldInner}>
                  									<div className={styles.groupChild} />
                								</div>
              							</div>
              							<div className={styles.entryField4}>
                								<div className={styles.iAgreeToContainer}>Confirm password</div>
                								<div className={styles.entryFieldInner}>
                  									<div className={styles.groupChild} />
                								</div>
              							</div>
              							<div className={styles.entryField5}>
                								<div className={styles.iAgreeToContainer}>
                  									<span>{`Date of birth `}</span>
                  									<span className={styles.mmddyy}>(MM/DD/YY)</span>
                								</div>
                								<div className={styles.entryFieldInner}>
                  									<div className={styles.groupChild} />
                								</div>
              							</div>
              							<div className={styles.entryField6}>
                								<div className={styles.iAgreeToContainer}>Last name</div>
                								<div className={styles.entryFieldInner}>
                  									<div className={styles.groupChild} />
                								</div>
              							</div>
              							<img className={styles.calendarMonthOutlineIcon1} alt="" src="calendar-month-outline.png" />
            						</div>
            						</div>
            						<div className={styles.text}>
              							<div className={styles.createAccount1}>Create Account For Doctor</div>
              							<div className={styles.forBusinessBand1}>For business, band or celebrity.</div>
            						</div>
            						<div className={styles.logo}>
              							<div className={styles.capzul}>Capzul</div>
              							<img className={styles.imgNewLogoLowQualityIcon1} alt="" src="img-new-logo-low-quality.png" />
            						</div>
            						</div>
            						<div className={styles.left}>
              							<div className={styles.bg} />
              							<div className={styles.sliderDots}>
                								<div className={styles.sliderDotsChild} />
                								<img className={styles.sliderDotsItem} alt="" src="Group 18.png" />
                								<div className={styles.sliderDotsChild} />
              							</div>
              							<div className={styles.leftChild} />
              							<div className={styles.imgs}>
                								<img className={styles.imgfeaturesArchive4Icon} alt="" src="imgfeatures-archive 4.png" />
                								<img className={styles.imgfeaturesArchive5Icon} alt="" src="imgfeatures-archive 5.png" />
                								<img className={styles.imgfeaturesArchive6Icon} alt="" src="imgfeatures-archive 6.png" />
              							</div>
              							<div className={styles.socialMediaShared1}>Social media shared today, tomorrow or by location</div>
            						</div>
                                    </div>
            						</div>);
          					};
          					
          					export default LoginPageDefaultStates;
          					