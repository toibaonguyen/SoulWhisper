import type { NextPage } from 'next';
import styles from './index.module.css';


const Desktop1:NextPage = () => {
  	return (
        <div className={styles.myBody}>
    		<div className={styles.desktop11}>
      			<div className={styles.background1} />
      			<div className={styles.banner2} />
      			<div className={styles.fullNameAndBio1}>
        				<img className={styles.fullNameAndBioChild} alt="" src="Ellipse 1.png" />
        				<b className={styles.khusanAkhmedov}>Khusan Akhmedov</b>
        				<div className={styles.uzbekistanTashkent}>Uzbekistan, Tashkent</div>
        				<div className={styles.imWebDesigner1}>I’m web designer, I work in programs like figma, adobe photoshop, adobe illustrator</div>
      			</div>
      			<div className={styles.shotsFollowersFollowing1}>
        				<div className={styles.shots}>Shots</div>
        				<div className={styles.followers}>Followers</div>
        				<div className={styles.following}>Following</div>
        				<div className={styles.div}>21</div>
        				<div className={styles.div1}>238</div>
        				<div className={styles.div2}>101</div>
        				<div className={styles.shotsFollowersFollowingChild} />
        				<div className={styles.shotsFollowersFollowingItem} />
      			</div>
      			<div className={styles.buttonFollow}>
        				<div className={styles.buttonFollowChild} />
        				<div className={styles.follow}>Follow</div>
      			</div>
      			<div className={styles.buttonMessage}>
        				<div className={styles.buttonMessageChild} />
        				<div className={styles.message}>Message</div>
      			</div>
      			<div className={styles.header1}>
        				<div className={styles.banner3} />
        				<div className={styles.header}>
          					<div className={styles.account}>Account</div>
          					<div className={styles.headerChild} />
          					<div className={styles.reposts}>Reposts</div>
          					<div className={styles.settings}>Settings</div>
          					<div className={styles.helpSupport1}>{`Help & Support`}</div>
        				</div>
        				<div className={styles.lines}>
          					<div className={styles.linesChild} />
          					<div className={styles.linesItem} />
          					<div className={styles.linesInner} />
        				</div>
      			</div>
                  </div>
    		</div>);
};

export default Desktop1;
