"use client";

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
  const healthCareQuotes: string[] = [
    "Healthcare is a human right. - Bernie Sanders",
    "The best doctor gives the least medicines. - Benjamin Franklin",
    "Prevention is better than cure. - Desiderius Erasmus",
    "The art of medicine consists of amusing the patient while nature cures the disease. - Voltaire",
    "The greatest wealth is health. - Virgil",
    "The doctor of the future will give no medicine but will interest his patients in the care of the human frame, in diet, and in the cause and prevention of disease. - Thomas Edison",
    "It is health that is the real wealth and not pieces of gold and silver. - Mahatma Gandhi",
    "Healthcare should be a right, not a privilege. It should be a right for every single American. - Barack Obama",
    "The first wealth is health. - Ralph Waldo Emerson",
    "Caring for the health of our citizens is the most important task of government. - Winston Churchill",
    "The good physician treats the disease; the great physician treats the patient who has the disease. - William Osler",
    "To keep the body in good health is a duty... otherwise we shall not be able to keep our mind strong and clear. - Buddha",
    "A healthy outside starts from the inside. - Robert Urich",
    "The doctor of the future will be oneself. - Albert Schweitzer",
    "Take care of your body. It's the only place you have to live. - Jim Rohn",
    "Let food be thy medicine and medicine be thy food. - Hippocrates",
    "Investing in health will produce enormous benefits. - Gro Harlem Brundtland",
    "Your body hears everything your mind says. Stay positive. - Unknown",
    "He who has health has hope, and he who has hope has everything. - Arabian Proverb",
    "The wish for healing has always been half of health. - Lucius Annaeus Seneca",
  ];
  const [healthCareQuote, SethealthCareQuote] = useState("");

  useEffect(() => {
    SetRecommendedDoctors(recommendDoctorsTestData);
    SethealthCareQuote(
      healthCareQuotes[Math.floor(Math.random() * healthCareQuotes.length)]
    );
  }, [onSearch]);

  const onSearchText = async (text: string) => {
    console.log(text);
  };

  const onClickDoctor = async (id: string) => {
    console.log("ID:", id);
  };

  return (
    <div className={styles.container}>
      <div style={{ display: "flex", justifyContent: "space-between" }}>
        <div>
          <ContentContainer>
            <div>
              <SearchBar onSearch={onSearchText} />
            </div>
          </ContentContainer>
        </div>
        <div style={{ padding: 15 }}>{healthCareQuote}</div>
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
