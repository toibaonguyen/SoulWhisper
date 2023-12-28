import React, { useEffect, useState } from "react";
import ContentContainer from "../ContentContainer";
import styles from "./index.module.css";
import SearchBar from "./SearchBar";
import { Avatar } from "@mui/material";
import DoctorProfile, { Doctor } from "./DoctorProfile";
import { recommendDoctorsTestData } from "./testData";
export default function Home() {
  const [onSearch, SetOnSearch] = useState(false);
  const [doctors, SetDoctors] = useState<Doctor[]>([]);
  const [recommendedDoctors, SetRecommendedDoctors] = useState<Doctor[]>([]);

  useEffect(() => {
    SetRecommendedDoctors(recommendDoctorsTestData);
  }, [onSearch]);

  const onSearchText = async (text: string) => {
    console.log(text);
  };

  const onClickDoctor = async (id: string) => {
    console.log("ID:", id);
  };

  return (
    <div className={styles.container}>
      <div style={{display:"flex",justifyContent:"space-between"}}>
        <div>
          <ContentContainer>
            <div>
              <SearchBar onSearch={onSearchText} />
            </div>
          </ContentContainer>
        </div>
        <div>
          <ContentContainer>
            <div>
              <SearchBar onSearch={onSearchText} />
            </div>
          </ContentContainer>
        </div>
      </div>
      {!onSearch && (
        <>
          <ContentContainer>
            <h4 style={{ marginLeft: 15 }}>Most popular doctors</h4>
          </ContentContainer>
          <div
            style={{
              alignSelf: "center",
              display: "grid",
              gap: 10,
              justifyItems: "center",
              gridTemplateColumns: "repeat(2, 1fr)",
            }}
          >
            {recommendedDoctors.map((d) => (
              <DoctorProfile
                id={d.id}
                avatar={d.avatar}
                name={d.name}
                medicalSpecialty={d.medicalSpecialty}
                rating={d.rating}
                onClick={onClickDoctor}
              />
            ))}
          </div>
        </>
      )}
    </div>
  );
}
